using DiveDeepWebApp.Api.Data;
using DiveDeepWebApp.Api.Persistence;
using DiveDeepWebApp.Api.Persistence.Interfaces;
using DiveDeepWebApp.Api.Service;
using DiveDeepWebApp.Api.Services;
using DiveDeepWebApp.Api.Services.Interfaces;
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

            builder.Services.AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DiveDeepContext>()
                .AddApiEndpoints();

            builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
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

            // Add services to the container.

            builder.Services.AddControllers();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
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

            
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<IPackageRepository, PackageRepository>();


            builder.Services.AddScoped<IWeatherService, WeatherService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<IPackageService, PackageService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            //app.UseRouting();
            //app.UseCors("SecurePolicy");
            app.MapIdentityApi<ApplicationUser>();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers().RequireCors("SecurePolicy");
            //});

            app.Run();
        }
    }
}
