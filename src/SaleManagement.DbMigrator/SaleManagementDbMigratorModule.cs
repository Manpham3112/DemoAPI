using SaleManagement.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace SaleManagement.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(SaleManagementEntityFrameworkCoreDbMigrationsModule),
        typeof(SaleManagementApplicationContractsModule)
        )]
    public class SaleManagementDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
