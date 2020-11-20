using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SaleManagement.Filters;

namespace SaleManagement
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<SaleManagementHttpApiHostModule>();
            services.AddMvc(options =>
            {
                options.Filters.AddService(typeof(ExceptionFilter), 0);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseStaticFiles();
            app.InitializeApplication();
        }
    }
}
