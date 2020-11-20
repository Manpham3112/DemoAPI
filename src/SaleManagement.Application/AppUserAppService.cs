using SaleManagement.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace SaleManagement
{
    public class AppUserAppService : ApplicationService, IAppUserAppService
    {
        private readonly IAppUserDomainService userService;
        private readonly IIdentityUserDomainService identityUserService;

        public AppUserAppService(IAppUserDomainService userService, IIdentityUserDomainService identityUserService)
        {
            this.userService = userService;
            this.identityUserService = identityUserService;
        }

        public List<AppUserDto> GetUsers(string searchString)
        {
            searchString = searchString ?? "";
            var users = userService.GetUsers(searchString);
            return ObjectMapper.Map<List<AppUser>, List<AppUserDto>>(users);
        }
    }
}
