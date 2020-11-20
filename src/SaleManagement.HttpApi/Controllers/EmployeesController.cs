using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaleManagement.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : SaleManagementController
    {
        private readonly IAppUserAppService userService;
        private readonly IIdentityUserApplicationService identityUserService;

        public EmployeesController(IAppUserAppService userService, IIdentityUserApplicationService identityUserService)
        {
            this.userService = userService;
            this.identityUserService = identityUserService;
        }

        [HttpGet]
        public List<AppUserDto> GetEmployees(string searchString)
        {
            return userService.GetUsers(searchString);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateUserDto user)
        {
            var newUser = await identityUserService.CreateUser(user);
            return Ok(new { Id = newUser.Id });
        }
    }
}
