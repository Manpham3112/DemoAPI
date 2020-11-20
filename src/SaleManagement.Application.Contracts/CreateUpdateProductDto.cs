using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaleManagement
{
    public class CreateUpdateProductDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public float Price { get; set; }

        public int Amount { get; set; }

        public IFormFile Image { get; set; }
    }
}
