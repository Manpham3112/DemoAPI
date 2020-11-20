using Microsoft.AspNetCore.Hosting;
using SaleManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Guids;

namespace SaleManagement
{
    public class RoomAppService : ApplicationService, IRoomAppService
    {
        private readonly IRoomDomainService roomDomainService;
        private readonly IGuidGenerator guidGenerator;
        private readonly IWebHostEnvironment webHostEnvironment;

        public RoomAppService(IRoomDomainService roomDomainService, IGuidGenerator guidGenerator, IWebHostEnvironment webHostEnvironment)
        {
            this.roomDomainService = roomDomainService;
            this.guidGenerator = guidGenerator;
            this.webHostEnvironment = webHostEnvironment;
        }




        public async Task CreateRoom(CreateUpdateRoomDto input)
        {
            var room = new Room(guidGenerator.Create())
            {
                Name = input.Name,
                Price = input.Price,
                Status = input.Status,
            };

            await roomDomainService.CreateRoom(room);
        }

        public async Task<List<RoomDto>> GetRoom()
        {
            var room = await roomDomainService.GetRoom();
            var roomDtos = ObjectMapper.Map<List<Room>, List<RoomDto>>(room);
            return roomDtos;
        }
        public RoomDto GetRoomById(Guid id)
        {
            try
            {
                var room = roomDomainService.GetRoomById(id);
                var roomDtos = ObjectMapper.Map<Room, RoomDto>(room);
                return roomDtos;
            }
            catch (Exception ex)
            {
                var a = ex;
                return null;
            }

        }

        public async Task DeleteRoom(Guid id)
        {
            await roomDomainService.DeleteRoom(id);
        }

        public async Task UpdateRoom(Guid id, CreateUpdateRoomDto input)
        {
            var room = new Room(id)
            {
                Name = input.Name,
                Price = input.Price,
                Status = input.Status
            };
            await roomDomainService.UpdateRoom(id, room);
        }

        public List<RoomDto> SearchRoom(string searchString)
        {
            var room = roomDomainService.SearchRoom(searchString);
            var roomDtos = ObjectMapper.Map<List<Room>, List<RoomDto>>(room);
            return roomDtos;
        }
    }
}
