using System.Threading.Tasks;

namespace SaleManagement.Data
{
    public interface ISaleManagementDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
