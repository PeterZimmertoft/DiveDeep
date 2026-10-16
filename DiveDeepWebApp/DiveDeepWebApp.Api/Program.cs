using DiveDeepWebApp.Api.Data;
using DiveDeepWebApp.Api.Persistence;
using DiveDeepWebApp.Api.Persistence.Interfaces;
using DiveDeepWebApp.Api.Services;
using DiveDeepWebApp.Api.Services.Interfaces;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace DiveDeepWebApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DiveDeepContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });

            string sharedKeysPath = Path.GetFullPath(
                Path.Combine(builder.Environment.ContentRootPath, "..", ".shared-keys"));

            builder.Services
                .AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(sharedKeysPath))
                .SetApplicationName("DiveDeep");

            builder.Services
                .AddIdentityApiEndpoints<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DiveDeepContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = ".DiveDeep.Identity";
                options.Cookie.Path = "/";
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.Lax;
            });

            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();

            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("SecurePolicy", policy =>
            //    {
            //        policy.WithOrigins(
            //            "https://localhost:7157"
            //            )
            //        .AllowCredentials()
            //        //.AllowAnyMethod()
            //        .WithMethods("GET", "POST", "PUT", "DELETE")
            //        .WithHeaders("Content-Type", "Authorization");
            //    });
            //});

            builder.Services.AddControllers();

            builder.Services.AddOpenApi();

            builder.Services.AddHttpClient("Geocode", (client) =>
            {
                client.BaseAddress = new Uri("https://geocoding-api.open-meteo.com/v1/");
            });

            builder.Services.AddHttpClient("Wave", (client) =>
            {
                client.BaseAddress = new Uri("https://marine-api.open-meteo.com/v1/");
            });

            builder.Services.AddHttpClient("Weather", (client) =>
            {
                client.BaseAddress = new Uri("https://api.open-meteo.com/v1/");
            });

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IPackageRepository, PackageRepository>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IPackageService, PackageService>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<IWeatherService, WeatherService>();
            builder.Services.AddScoped<IBookingService, BookingService>();

            var app = builder.Build();

            app.Lifetime.ApplicationStarted.Register(() =>
            {
                _ = Task.Run(async () =>
                {
                    try
                    {
                        using IServiceScope scope = app.Services.CreateScope();
                        DiveDeepContext context = scope.ServiceProvider.GetRequiredService<DiveDeepContext>();
                        await ImageSeeder.SeedAsync(context);
                    }
                    catch (Exception ex)
                    {
                        app.Logger.LogError(ex, "Image seeding failed.");
                    }
                });
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapIdentityApi<ApplicationUser>();
            app.MapControllers();

            app.Run();
        }
    }
}
