using System;
using Volo.Abp.Domain.Entities;

namespace SaleManagement.Models
{
    public class ImportReceiptDetail : Entity
    {
        public Guid ProductId { get; set; }
        
        public Guid ImportReceiptId { get; set; }

        public int ProductAmount { get; set; }

        public float ProductPrice { get; set; }

        public Guid DistributorId { get; set; }

        public Product Product { get; set; }

        public ImportReceipt ImportReceipt { get; set; }

        public Distributor Distributor { get; set; }

        public override object[] GetKeys()
        {
            return new object[] { ProductId, ImportReceiptId };
        }
    }
}
