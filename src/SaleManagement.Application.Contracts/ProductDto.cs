using System;
using Volo.Abp.Application.Dtos;

namespace SaleManagement
{
    public class ProductDto: EntityDto<Guid>
    {
        public string Name { get; set; }

        public float Price { get; set; }

        public int Amount { get; set; }

        public string Image { get; set; }
    }
}
