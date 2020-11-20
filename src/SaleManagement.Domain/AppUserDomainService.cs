using SaleManagement.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace SaleManagement
{
    public class AppUserDomainService : DomainService, IAppUserDomainService
    {
        private readonly IRepository<AppUser> userRepository;

        public AppUserDomainService(IRepository<AppUser> userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<AppUser> GetUsers(string searchString)
        {
            return userRepository
                .Where(u => 
                    u.Name.Contains(searchString) ||
                    u.Email.Contains(searchString) ||
                    u.PhoneNumber.Contains(searchString) ||
                    u.Address.Contains(searchString))
                .ToList();
        }
        
        public async Task<AppUser> GetUser(Guid userId)
        {
            return await userRepository.GetAsync(user => user.Id == userId);
        }

        public async Task<AppUser> CreateUser(AppUser user)
        {
            return await userRepository.InsertAsync(user);
        }

        public async Task UpdateUser(Guid userId, AppUser user)
        {
            var samePhoneNumberUser = userRepository.FirstOrDefault(u => u.PhoneNumber == user.PhoneNumber);
            if (samePhoneNumberUser != null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, SaleManagementDomainErrorCodes.PHONE_NUMBER_IS_TAKEN);
            }

            var updatedUser = await userRepository.GetAsync(user => user.Id == userId);
            updatedUser.Name = user.Name;
            updatedUser.PhoneNumber = user.PhoneNumber;
            updatedUser.DateOfBirth = user.DateOfBirth;
            updatedUser.Address = user.Address;
        }
    }
}
