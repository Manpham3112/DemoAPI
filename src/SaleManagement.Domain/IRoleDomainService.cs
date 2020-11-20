using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;

namespace SaleManagement
{
    public interface IRoleDomainService : IDomainService
    {
        Task<List<IdentityRole>> GetRoles();
    }
}
