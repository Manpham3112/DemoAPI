using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace SaleManagement
{
    public interface IIdentityUserApplicationService : IApplicationService
    {
        Task<Profile> GetProfile(Guid userId);
        Task<AuthOutput> GetAuthInfo(AuthInput input);
        Task<IdentityUserDto> CreateUser(CreateUserDto userDto);
    }
}
