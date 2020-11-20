
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace SaleManagement.Models
{
    public class Room : Entity<Guid>
    {
        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        public float Price { get; set; }

        public int Status { get; set; }

        public Room(Guid id) : base(id)
        {

        }
    }
}