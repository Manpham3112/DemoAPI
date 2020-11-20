using System;
using Volo.Abp.Application.Dtos;

namespace SaleManagement
{
    public class RoomDto: EntityDto<Guid>
    {
        public string Name { get; set; }

        public float Price { get; set; }

        public int Status { get; set; }
    }
}
