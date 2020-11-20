﻿using SaleManagement.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace SaleManagement.Models
{
    public class ImportReceipt : Entity<Guid>
    {
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }

        public float TotalPrice { get; set; }

        public Guid UserId { get; set; }

        public AppUser User { get; set; }

        public ICollection<ImportReceiptDetail> ImportReceiptDetails { get; set; }
    }
}
