using SaleManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SaleManagement
{
    [DependsOn(
        typeof(SaleManagementEntityFrameworkCoreTestModule)
        )]
    public class SaleManagementDomainTestModule : AbpModule
    {

    }
}