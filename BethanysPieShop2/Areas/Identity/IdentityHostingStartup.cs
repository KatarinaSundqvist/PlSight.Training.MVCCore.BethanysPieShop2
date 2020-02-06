using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(BethanysPieShop2.Areas.Identity.IdentityHostingStartup))]
namespace BethanysPieShop2.Areas.Identity {
    public class IdentityHostingStartup : IHostingStartup {
        public void Configure(IWebHostBuilder builder) {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}