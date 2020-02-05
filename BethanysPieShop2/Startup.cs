using BethanysPieShop2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BethanysPieShop2 {
    public class Startup {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) {

            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPieRepository, PieRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));
            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession(); // Make sure to call UseSession before UseRouting

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        // The order in which you call the middleware is definitely important
        // When unsure of the correct order, look it up!
    }
}