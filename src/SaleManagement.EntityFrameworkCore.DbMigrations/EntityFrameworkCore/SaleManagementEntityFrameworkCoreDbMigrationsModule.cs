using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace SaleManagement.EntityFrameworkCore
{
    [DependsOn(
        typeof(SaleManagementEntityFrameworkCoreModule)
        )]
    public class SaleManagementEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<SaleManagementMigrationsDbContext>();
        }
    }
}
