using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SaleManagement.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : SaleManagementController
    {
        private readonly IIdentityUserApplicationService userAppService;

        public AuthController(IIdentityUserApplicationService userAppService)
        {
            this.userAppService = userAppService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthInput input)
        {
            var authInfo = await userAppService.GetAuthInfo(input);
            return Ok(authInfo);
        }
    }
}
