using SaleManagement.Users;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;
using Volo.Abp.Uow;

namespace SaleManagement
{
    public class IdentityUserDomainService : DomainService, IIdentityUserDomainService
    {
        private readonly IRepository<AppUser> userRepository;
        private readonly IRepository<IdentityUser> _identityUserRepository;
        private readonly IdentityUserManager userManager;
        private readonly IUnitOfWorkManager unitOfWorkManager;

        public IdentityUserDomainService(IRepository<AppUser> userRepository,
            IdentityUserManager userManager,
            IUnitOfWorkManager unitOfWorkManager,
            IRepository<IdentityUser> identityUserRepository)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
            this.unitOfWorkManager = unitOfWorkManager;
            _identityUserRepository = identityUserRepository;
        }

        public IdentityUser GetUser(Guid userId)
        {
            return _identityUserRepository.FirstOrDefault(u => u.Id == userId);
        }

        public async Task<IdentityUser> CheckLogin(string username, string password)
        {
            var identityUser = _identityUserRepository.FirstOrDefault(u => u.UserName == username);

            if (identityUser == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, SaleManagementDomainErrorCodes.USERNAME_PASSWORD_IS_NOT_CORRECT);
            }

            var now = DateTime.Now;
            var lastLockedDate = identityUser.GetProperty("LastLockedDate");
            if (lastLockedDate != null && (DateTime)lastLockedDate > now)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, SaleManagementDomainErrorCodes.ACCOUNT_IS_LOCKED);
            }

            var user = userRepository.FirstOrDefault(u => u.Id == identityUser.Id);
            if (!await userManager.CheckPasswordAsync(identityUser, password))
            {
                if (user.Locked)
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest, SaleManagementDomainErrorCodes.ACCOUNT_IS_LOCKED);
                }

                using (var unitOfWork = unitOfWorkManager.Begin(requiresNew: true))
                {
                    user.FailedLoginsNumber = user.FailedLoginsNumber + 1;

                    if (user.FailedLoginsNumber == 3)
                    {
                        user.Locked = true;
                        user.LastLockedDate = now.AddSeconds(30);
                    }
                    await userRepository.UpdateAsync(user);
                    await unitOfWork.SaveChangesAsync();
                }
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, SaleManagementDomainErrorCodes.USERNAME_PASSWORD_IS_NOT_CORRECT);
            }


            if (user.Locked)
            {
                user.FailedLoginsNumber = 0;
                user.Locked = false;
                user.LastLockedDate = null;
            }

            return identityUser;
        }

        public async Task AddPassword(IdentityUser user, string password)
        {
            await userManager.AddPasswordAsync(user, password);
        }

        public async Task<IdentityUser> CreateUser(IdentityUser user, string password)
        {
            var sameInfoUsers = userRepository
                .Where(u => u.UserName.ToLower() == user.UserName.ToLower() || u.Email.ToLower() == user.Email.ToLower())
                .ToList();

            foreach(var sameInfoUser in sameInfoUsers)
            {
                if (sameInfoUser.UserName.ToLower() == user.UserName.ToLower())
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest, SaleManagementDomainErrorCodes.USERNAME_IS_TAKEN);
                }
                if (sameInfoUser.Email.ToLower() == user.Email.ToLower())
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest, SaleManagementDomainErrorCodes.EMAIL_IS_TAKEN);
                }
            }

            var result = await userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                throw new HttpStatusCodeException(HttpStatusCode.InternalServerError, SaleManagementDomainErrorCodes.CREATE_USER_FAILED);
            }

            result = await userManager.AddToRoleAsync(user, "employee");
            if (!result.Succeeded)
            {
                throw new HttpStatusCodeException(HttpStatusCode.InternalServerError, SaleManagementDomainErrorCodes.CREATE_USER_FAILED);
            }

            return user;
        }
    }
}
