using System.ComponentModel.DataAnnotations;

namespace SaleManagement
{
    public class AuthInput
    {
        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }
    }
}
