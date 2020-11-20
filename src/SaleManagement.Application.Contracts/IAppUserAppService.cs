using System.Collections.Generic;
using Volo.Abp.Application.Services;

namespace SaleManagement
{
    public interface IAppUserAppService : IApplicationService
    {
        List<AppUserDto> GetUsers(string searchString);
    }
}
