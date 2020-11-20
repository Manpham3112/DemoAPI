using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SaleManagement.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace SaleManagement
{
    public class IdentityUserApplicationService : ApplicationService, IIdentityUserApplicationService
    {
        private readonly IIdentityUserDomainService identityUserService;
        private readonly IAppUserDomainService userService;
        private readonly IdentityUserManager userManager;
        private readonly IConfiguration configuration;

        public IdentityUserApplicationService(
            IIdentityUserDomainService identityUserService,
            IdentityUserManager userManager, 
            IConfiguration configuration,
            IAppUserDomainService userService)
        {
            this.identityUserService = identityUserService;
            this.userManager = userManager;
            this.configuration = configuration;
            this.userService = userService;
        }

        public async Task<AuthOutput> GetAuthInfo(AuthInput input)
        {
            var user = await identityUserService.CheckLogin(input.Username, input.Password);
            var roles = await userManager.GetRolesAsync(user);
            var authOutput = new AuthOutput
            {
                AccessToken = GenerateToken(user, roles[0]),
                ExpiresIn = 24 * 60 * 60
            };

            return authOutput;
        }

        private string GenerateToken(IdentityUser user, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Role, role)
            };
            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Issuer"],
                claims,
                null,
                DateTime.Now.AddMinutes(24 * 60),
                credential
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<Profile> GetProfile(Guid userId)
        {
            var user = identityUserService.GetUser(userId);
            var profile = new Profile()
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                Name = user.Name
            };
            var role = await userManager.GetRolesAsync(user);
            profile.Role = role[0];

            return profile;
        }

        public async Task<IdentityUserDto> CreateUser(CreateUserDto userDto)
        {
            var identityUser = new IdentityUser(GuidGenerator.Create(), userDto.UserName, userDto.Email);
            await identityUserService.CreateUser(identityUser, userDto.Password);

            var user = ObjectMapper.Map<CreateUserDto, AppUser>(userDto);
            await userService.UpdateUser(identityUser.Id, user);

            return ObjectMapper.Map<IdentityUser, IdentityUserDto>(identityUser);
        }
    }
}
