using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;

namespace SaleManagement
{
    public class RoleDomainService : DomainService, IRoleDomainService
    {
        private readonly IRepository<IdentityRole> roleRepository;

        public RoleDomainService(IRepository<IdentityRole> roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public async Task<List<IdentityRole>> GetRoles()
        {
            return await roleRepository.GetListAsync();
        }
    }
}
