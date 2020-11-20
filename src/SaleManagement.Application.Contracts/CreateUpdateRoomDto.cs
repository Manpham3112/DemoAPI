using System.ComponentModel.DataAnnotations;

namespace SaleManagement
{
    public class CreateUpdateRoomDto
    {
        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        public float Price { get; set; }

        public int Status { get; set; }
    }
}
