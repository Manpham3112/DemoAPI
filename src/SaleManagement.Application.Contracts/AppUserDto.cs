using System;
using Volo.Abp.Application.Dtos;

namespace SaleManagement
{
    public class AppUserDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}
