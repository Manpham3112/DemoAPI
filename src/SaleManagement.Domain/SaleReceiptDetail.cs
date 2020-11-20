using System;
using Volo.Abp.Domain.Entities;

namespace SaleManagement.Models
{
    public class SaleReceiptDetail : Entity
    {
        public Guid ProductId { get; set; }

        public Guid SaleReceiptId { get; set; }

        public int ProductAmount { get; set; }

        public float ProductPrice { get; set; }

        public Product Product { get; set; }

        public SaleReceipt SaleReceipt { get; set; }

        public override object[] GetKeys()
        {
            return new object[] { ProductId, SaleReceiptId };
        }
    }
}
