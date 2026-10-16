using DiveDeepWebApp.Data;

namespace DiveDeepWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // builder.Services.AddDbContext<DiveDeepContext>(options =>
            // {
            //     options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            // });

            // builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //     .AddRoles<IdentityRole>()
            //     .AddEntityFrameworkStores<DiveDeepContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //
            // builder.Services.AddHttpClient("Geocode", (client) =>
            // {
            //     client.BaseAddress = new Uri("https://geocoding-api.open-meteo.com/v1/");
            // });
            //
            // builder.Services.AddHttpClient("Wave", (client) =>
            // {
            //     client.BaseAddress = new Uri("https://marine-api.open-meteo.com/v1/");
            // }
            // );
            //
            // builder.Services.AddHttpClient("Weather", (client) =>
            // {
            //     client.BaseAddress = new Uri("https://api.open-meteo.com/v1/");
            // }
// );

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
