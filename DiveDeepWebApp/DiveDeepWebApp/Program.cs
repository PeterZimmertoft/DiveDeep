using DiveDeepWebApp.Handlers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;

namespace DiveDeepWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            string sharedKeysPath = Path.GetFullPath(
                Path.Combine(builder.Environment.ContentRootPath, "..", ".shared-keys"));

            builder.Services
                .AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(sharedKeysPath))
                .SetApplicationName("DiveDeep");

            builder.Services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme =
                        IdentityConstants.ApplicationScheme;

                    options.DefaultChallengeScheme =
                        IdentityConstants.ApplicationScheme;
                })
                .AddCookie(IdentityConstants.ApplicationScheme, options =>
                {
                    options.Cookie.Name = ".DiveDeep.Identity";
                    options.Cookie.Path = "/";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.Cookie.SameSite = SameSiteMode.Lax;

                    options.LoginPath = "/account/login";
                    options.AccessDeniedPath = "/account/access-denied";
                });

            builder.Services.AddAuthorization();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddTransient<IdentityCookieHandler>();

            builder.Services
                .AddHttpClient("DiveDeepApi", client =>
                {
                    client.BaseAddress = new Uri(
                        builder.Configuration["Api:BaseUrl"]!);
                })
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                {
                    UseCookies = false
                })
                .AddHttpMessageHandler<IdentityCookieHandler>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

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
            // app.MapRazorPages();

            app.MapControllerRoute(name: "package", pattern: "package/{packageId}", defaults: new { controller = "Packages", action = "Package" });
            app.MapControllerRoute(name: "category", pattern: "products/{categoryId}", defaults: new { controller = "Products", action = "Products" });
            app.MapControllerRoute(name: "product", pattern: "products/{categoryId}/{productId}", defaults: new { controller = "Products", action = "Product" });

            app.MapControllerRoute(name: "cart", pattern: "cart", defaults: new { controller = "Cart", action = "Index" });
            app.MapControllerRoute(name: "cart-remove", pattern: "cart/remove/{cartItemId}", defaults: new { controller = "Cart", action = "Remove" });

            app.MapControllerRoute(name: "booking-edit", pattern: "bookings/edit/{bookingId}", defaults: new { controller = "Bookings", action = "Edit" });
            app.MapControllerRoute(name: "admin-booking-edit", pattern: "admin/bookings/edit/{bookingId}", defaults: new { controller = "Admin", action = "EditBooking" });
            
            app.MapControllerRoute(name: "admin-product-create", pattern: "admin/products/create", defaults: new { controller = "Admin", action = "CreateProduct" });
            app.MapControllerRoute(name: "admin-product-edit", pattern: "admin/products/edit/{productId}", defaults: new { controller = "Admin", action = "EditProduct" });
            app.MapControllerRoute(name: "admin-product-delete", pattern: "admin/products/{productId}/delete", defaults: new { controller = "Admin", action = "DeleteProductVariant" });
            app.MapControllerRoute(name: "admin-product-delete-variant", pattern: "admin/products/variants/{productId}/delete", defaults: new { controller = "Admin", action = "DeleteProductVariant" });

            app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}").WithStaticAssets();

            app.Run();
        }
    }
}
