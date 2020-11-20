using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace SaleManagement.Models
{
    public class Product : Entity<Guid>, ISoftDelete
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public float Price { get; set; }

        public int Amount { get; set; }

        public string Image { get; set; }

        public ICollection<SaleReceiptDetail> SaleReceiptDetails { get; set; }

        public ICollection<ImportReceiptDetail> ImportReceiptDetails { get; set; }

        public bool IsDeleted { get; set; }
        
        public Product(Guid id): base(id)
        {

        }
    }
}
