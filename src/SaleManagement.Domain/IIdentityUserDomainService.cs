using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;

namespace SaleManagement
{
    public interface IIdentityUserDomainService : IDomainService
    {
        IdentityUser GetUser(Guid userId);
        Task<IdentityUser> CheckLogin(string username, string password);
        Task AddPassword(IdentityUser user, string password);
        Task<IdentityUser> CreateUser(IdentityUser user, string password);
    }
}
