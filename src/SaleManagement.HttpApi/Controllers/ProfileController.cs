using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SaleManagement.Controllers
{
    [Route("api/profile")]
    [Authorize]
    public class ProfileController : SaleManagementController
    {
        private readonly IIdentityUserApplicationService userService;

        public ProfileController(IIdentityUserApplicationService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var profile = await userService.GetProfile(CurrentUser.Id.Value);
            return Ok(profile);
        }
    }
}
