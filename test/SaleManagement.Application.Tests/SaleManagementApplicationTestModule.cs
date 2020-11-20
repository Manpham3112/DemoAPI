using Volo.Abp.Modularity;

namespace SaleManagement
{
    [DependsOn(
        typeof(SaleManagementApplicationModule),
        typeof(SaleManagementDomainTestModule)
        )]
    public class SaleManagementApplicationTestModule : AbpModule
    {

    }
}