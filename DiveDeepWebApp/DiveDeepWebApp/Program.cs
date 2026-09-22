using DiveDeepWebApp.Data;
using DiveDeepWebApp.Persistence;
using DiveDeepWebApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DiveDeepWebApp
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

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DiveDeepContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IPackageRepository, PackageRepository>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IPackageService, PackageService>();
            builder.Services.AddScoped<ICartService, CartService>();

            var app = builder.Build();

            app.Lifetime.ApplicationStarted.Register(() =>
            {
                _ = Task.Run(async () =>
                {
                    try
                    {
                        using var scope = app.Services.CreateScope();
                        var context = scope.ServiceProvider.GetRequiredService<DiveDeepContext>();
                        await ImageSeeder.SeedAsync(context);
                    }
                    catch (Exception ex)
                    {
                        app.Logger.LogError(ex, "Image seeding failed.");
                    }
                });
            });

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages();

            app.MapControllerRoute(
                name: "package",
                pattern: "package/{packageId}",
                defaults: new { controller = "Packages", action = "Package" });

            app.MapControllerRoute(
                name: "product",
                pattern: "products/{categoryId}/{productId}",
                defaults: new { controller = "Products", action = "Product" });

            app.MapControllerRoute(
                name: "category",
                pattern: "products/{categoryId}",
                defaults: new { controller = "Products", action = "Products" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
