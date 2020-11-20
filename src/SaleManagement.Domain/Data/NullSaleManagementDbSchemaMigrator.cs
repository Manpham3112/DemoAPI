using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SaleManagement.Data
{
    /* This is used if database provider does't define
     * ISaleManagementDbSchemaMigrator implementation.
     */
    public class NullSaleManagementDbSchemaMigrator : ISaleManagementDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}