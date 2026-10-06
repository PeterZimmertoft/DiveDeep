using DiveDeepWebApp.Models;
using DiveDeepWebApp.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace DiveDeepWebApp.Tests;

[TestClass]
public sealed class WeatherServiceTests
{
    [TestMethod]
    public async Task GetGeocodeByNameAsync_Aarhus_ReturnsLocationData()
    {
        // Arrange
        using var application = new WebApplicationFactory<Program>();
        using IServiceScope scope = application.Services.CreateScope();
        IWeatherService service = scope.ServiceProvider.GetRequiredService<IWeatherService>();

        // Act
        GeocodeResponse result = await service.GetGeocodeByNameAsync("Aarhus");

        // Assert
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Results);
        Assert.IsGreaterThan(0, result.Results.Count);
        Assert.AreEqual("Aarhus", result.Results[0].Name);
        Assert.AreEqual("Denmark", result.Results[0].Country);
    }

    [TestMethod]
    public async Task GetCurrentWeatherByGeocodeAsync_Aarhus_ReturnsWeatherData()
    {
        // Arrange
        using var application = new WebApplicationFactory<Program>();
        using IServiceScope scope = application.Services.CreateScope();
        IWeatherService service = scope.ServiceProvider.GetRequiredService<IWeatherService>();

        // Act
        GeocodeResponse geocode = await service.GetGeocodeByNameAsync("Aarhus");
        GeocodeResult aarhus = geocode.Results[0];
        CurrentWeatherResponse result = await service.GetCurrentWeatherByGeocodeAsync(aarhus);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.CurrentWeather);
        Assert.IsGreaterThanOrEqualTo(0, result.CurrentWeather.WindSpeed10m);
        Assert.IsGreaterThanOrEqualTo(0, result.CurrentWeather.Precipitation);
        Assert.IsGreaterThanOrEqualTo(0, result.CurrentWeather.WeatherCode);
    }

    [TestMethod]
    public async Task GetWaveHeightByGeocodeAsync_Aarhus_ReturnsMarineData()
    {
        // Arrange
        using var application = new WebApplicationFactory<Program>();
        using IServiceScope scope = application.Services.CreateScope();
        IWeatherService service = scope.ServiceProvider.GetRequiredService<IWeatherService>();

        // Act
        GeocodeResponse geocode = await service.GetGeocodeByNameAsync("Aarhus");
        GeocodeResult aarhus = geocode.Results[0];
        WaveHeightResponse result = await service.GetWaveHeightByGeocodeAsync(aarhus);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.CurrentHeightAndTemp);
        Assert.IsGreaterThan(0, result.CurrentHeightAndTemp.Time);
        Assert.IsGreaterThanOrEqualTo(0, result.CurrentHeightAndTemp.WaveHeight);
    }

    [TestMethod]
    public async Task GetWeatherViewModel_Aarhus_CombinesWeatherData()
    {
        // Arrange
        using var application = new WebApplicationFactory<Program>();
        using IServiceScope scope = application.Services.CreateScope();
        IWeatherService service = scope.ServiceProvider.GetRequiredService<IWeatherService>();

        // Act
        var result = await service.GetWeatherViewModel("Aarhus");

        // Assert
        Assert.IsTrue(string.IsNullOrEmpty(result.ErrorMessage));
        Assert.AreEqual("Aarhus", result.City);
        Assert.AreEqual("Denmark", result.Country);
        Assert.IsGreaterThanOrEqualTo(0, result.WaveHeight);
        Assert.IsGreaterThanOrEqualTo(0, result.WindSpeed10m);
        Assert.StartsWith("Anbefaling: ", result.SuitRecommendedThickness);
    }

    [TestMethod]
    public async Task GetWeatherViewModel_UnknownPlace_ReturnsErrorMessage()
    {
        // Arrange
        using var application = new WebApplicationFactory<Program>();
        using IServiceScope scope = application.Services.CreateScope();
        IWeatherService service = scope.ServiceProvider.GetRequiredService<IWeatherService>();

        // Act
        var result = await service.GetWeatherViewModel("DetteStedFindesIkke987654321");

        // Assert
        Assert.AreEqual("Kunne ikke finde oplysninger. Prøv igen.", result.ErrorMessage);
    }
}
