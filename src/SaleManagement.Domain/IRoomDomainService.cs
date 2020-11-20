using SaleManagement.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace SaleManagement
{
    public interface IRoomDomainService : IDomainService
    {
        Task<Room> CreateRoom(Room room);
        Task<List<Room>> GetRoom();
        Task DeleteRoom(Guid id);
        List<Room> SearchRoom(string searchString);
        Task UpdateRoom(Guid id, Room room);
        Room GetRoomById(Guid id);

    }
}
