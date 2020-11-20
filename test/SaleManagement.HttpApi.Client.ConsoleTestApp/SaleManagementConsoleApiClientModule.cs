using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace SaleManagement.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(SaleManagementHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class SaleManagementConsoleApiClientModule : AbpModule
    {
        
    }
}
