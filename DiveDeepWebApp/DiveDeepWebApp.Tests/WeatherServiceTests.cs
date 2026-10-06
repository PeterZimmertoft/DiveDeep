using System.Net;
using System.Text;
using DiveDeepWebApp.Models;
using DiveDeepWebApp.Services;

namespace DiveDeepWebApp.Tests;

[TestClass]
public sealed class WeatherServiceTests
{
    [TestMethod]
    public async Task GetGeocodeByNameAsync_SuccessfulResponse_ReturnsFirstLocationData()
    {
        // Arrange
        var factory = new StubHttpClientFactory(_ => JsonResponse("""
            { "results": [{ "name": "Aarhus", "latitude": 56.16, "longitude": 10.21, "country": "Denmark" }] }
            """));
        var service = new WeatherService(factory);

        // Act
        GeocodeResponse result = await service.GetGeocodeByNameAsync("Aarhus");

        // Assert
        Assert.IsNotNull(result);
        Assert.HasCount(1, result.Results);
        Assert.AreEqual("Aarhus", result.Results[0].Name);
        Assert.AreEqual("https://example.test/search?name=Aarhus&count=1", factory.Requests.Single().ToString());
    }

    [TestMethod]
    public async Task GetCurrentWeatherByGeocodeAsync_SuccessfulResponse_ReturnsWeatherDataAndCorrectQuery()
    {
        // Arrange
        var factory = new StubHttpClientFactory(_ => JsonResponse("""
            { "current": { "wind_speed_10m": 12.5, "precipitation": 0.8, "weather_code": 95 } }
            """));
        var service = new WeatherService(factory);
        var geocode = new GeocodeResult { Latitude = 56.16, Longitude = 10.21 };

        // Act
        CurrentWeatherResponse result = await service.GetCurrentWeatherByGeocodeAsync(geocode);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(12.5, result.CurrentWeather.WindSpeed10m);
        Assert.Contains(factory.Requests.Single().Query, "latitude=56.16&longitude=10.21");
    }

    [TestMethod]
    public async Task GetWaveHeightByGeocodeAsync_SuccessfulResponse_ReturnsMarineData()
    {
        // Arrange
        var factory = new StubHttpClientFactory(_ => JsonResponse("""
            { "current": { "time": 1791244800, "wave_height": 0.7, "sea_surface_temperature": 14.5 } }
            """));
        var service = new WeatherService(factory);
        var geocode = new GeocodeResult { Latitude = 56.16, Longitude = 10.21 };

        // Act
        WaveHeightResponse result = await service.GetWaveHeightByGeocodeAsync(geocode);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(0.7, result.CurrentHeightAndTemp.WaveHeight);
        Assert.AreEqual(14.5, result.CurrentHeightAndTemp.SeaTemp);
        Assert.StartsWith("/marine?", factory.Requests.Single().PathAndQuery);
    }

    [TestMethod]
    public async Task GetGeocodeByNameAsync_UnsuccessfulResponse_ReturnsNull()
    {
        // Arrange
        var factory = new StubHttpClientFactory(_ => new HttpResponseMessage(HttpStatusCode.BadRequest));
        var service = new WeatherService(factory);

        // Act
        GeocodeResponse result = await service.GetGeocodeByNameAsync("unknown");

        // Assert
        Assert.IsNull(result);
    }

    [DataTestMethod]
    [DataRow(24.0, "Anbefaling: våddragt på 3mm")]
    [DataRow(18.0, "Anbefaling: våddragt på 5mm")]
    [DataRow(10.0, "Anbefaling: våddragt på 7mm")]
    [DataRow(9.9, "Anbefaling: tørdragt")]
    public async Task GetWeatherViewModel_ValidResponses_ReturnsCombinedWeatherAndSuitRecommendation(
        double seaTemperature,
        string expectedRecommendation)
    {
        // Arrange
        var factory = CreateWeatherFactory(seaTemperature, weatherCode: 95);
        var service = new WeatherService(factory);

        // Act
        var result = await service.GetWeatherViewModel("Aarhus");

        // Assert
        Assert.AreEqual("Aarhus", result.City);
        Assert.AreEqual("Denmark", result.Country);
        Assert.AreEqual(0.7, result.WaveHeight);
        Assert.AreEqual(12.5, result.WindSpeed10m);
        Assert.AreEqual(0.8, result.Precipitation);
        Assert.IsTrue(result.Thunder);
        Assert.AreEqual(expectedRecommendation, result.SuitRecommendedThickness);
        Assert.HasCount(3, factory.Requests);
    }

    [TestMethod]
    public async Task GetWeatherViewModel_MarineDataUnavailable_ReturnsCoastalCityError()
    {
        // Arrange
        StubHttpClientFactory factory = CreateWeatherFactory(seaTemperature: 14.5, weatherCode: 1, marineJson: "null");
        var service = new WeatherService(factory);

        // Act
        var result = await service.GetWeatherViewModel("Herning");

        // Assert
        Assert.AreEqual("Vi kan kun tjekke havforhold for kystbyer.", result.ErrorMessage);
    }

    [TestMethod]
    public async Task GetWeatherViewModel_GeocodeRequestFails_ReturnsGenericError()
    {
        // Arrange
        var factory = new StubHttpClientFactory(name => name == "Geocode"
            ? new HttpResponseMessage(HttpStatusCode.InternalServerError)
            : JsonResponse("{}"));
        var service = new WeatherService(factory);

        // Act
        var result = await service.GetWeatherViewModel("unknown");

        // Assert
        Assert.AreEqual("Kunne ikke finde oplysninger. Prøv igen.", result.ErrorMessage);
    }

    private static StubHttpClientFactory CreateWeatherFactory(
        double seaTemperature,
        int weatherCode,
        string? marineJson = null) => new(name => name switch
        {
            "Geocode" => JsonResponse("""
                { "results": [{ "name": "Aarhus", "latitude": 56.16, "longitude": 10.21, "country": "Denmark" }] }
                """),
            "Weather" => JsonResponse($$"""
                { "current": { "wind_speed_10m": 12.5, "precipitation": 0.8, "weather_code": {{weatherCode}} } }
                """),
            "Wave" => JsonResponse(marineJson ?? $$"""
                { "current": { "time": 1791244800, "wave_height": 0.7, "sea_surface_temperature": {{seaTemperature}} } }
                """),
            _ => throw new InvalidOperationException($"Unexpected client name: {name}")
        });

    private static HttpResponseMessage JsonResponse(string json) => new(HttpStatusCode.OK)
    {
        Content = new StringContent(json, Encoding.UTF8, "application/json")
    };

    private sealed class StubHttpClientFactory(Func<string, HttpResponseMessage> responseFactory) : IHttpClientFactory
    {
        public List<Uri> Requests { get; } = [];

        public HttpClient CreateClient(string name) => new(new StubHttpMessageHandler(request =>
        {
            Requests.Add(request.RequestUri!);
            return responseFactory(name);
        }))
        {
            BaseAddress = new Uri("https://example.test/")
        };
    }

    private sealed class StubHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> responseFactory)
        : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken) => Task.FromResult(responseFactory(request));
    }
}
