using SaleManagement.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace SaleManagement
{
    public interface IAppUserDomainService : IDomainService
    {
        List<AppUser> GetUsers(string searchString);
        Task<AppUser> GetUser(Guid userId);
        Task<AppUser> CreateUser(AppUser user);
        Task UpdateUser(Guid userId, AppUser user);
    }
}
