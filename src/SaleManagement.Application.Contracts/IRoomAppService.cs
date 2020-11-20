using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SaleManagement
{
    public interface IRoomAppService: IApplicationService
    {
        Task CreateRoom(CreateUpdateRoomDto input);

        Task<List<RoomDto>> GetRoom();

        List<RoomDto> SearchRoom(string searchString);

        Task UpdateRoom(Guid id, CreateUpdateRoomDto input);

        Task DeleteRoom(Guid id);
        RoomDto GetRoomById(Guid id);
    }
}
