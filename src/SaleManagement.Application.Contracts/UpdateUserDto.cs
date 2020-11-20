using System;
using System.ComponentModel.DataAnnotations;

namespace SaleManagement
{
    public class UpdateUserDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Address { get; set; }
    }
}
