using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace SaleManagement.Models
{
    public class Distributor : Entity<Guid>
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        public ICollection<ImportReceiptDetail> ImportReceiptDetails { get; set; }
    }
}
