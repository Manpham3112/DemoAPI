using Microsoft.AspNetCore.Hosting;
using SaleManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace SaleManagement
{
    public class RoomDomainService : DomainService, IRoomDomainService
    {
        private readonly IRepository<Room> _roomRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public RoomDomainService(IRepository<Room> roomRepository, IWebHostEnvironment webHostEnvironment)
        {
            _roomRepository = roomRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<Room> CreateRoom(Room room)
        {
            try
            {
                var existingRoom = _roomRepository.FirstOrDefault(p => p.Name == room.Name);
                if (existingRoom != null)
                {
                    throw new HttpStatusCodeException(HttpStatusCode.BadRequest, SaleManagementDomainErrorCodes.ROOM_NAME_IS_TAKEN);
                }
                return await _roomRepository.InsertAsync(room, true);
            }
            catch (Exception ex) { 
                var e = ex; 
                return new Room(Guid.NewGuid()); }
        }

        public async Task DeleteRoom(Guid id)
        {
            var room = await _roomRepository.GetAsync(p => p.Id == id);
            if (room == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, SaleManagementDomainErrorCodes.ROOM_NOT_FOUND);
            }
            await _roomRepository.DeleteAsync(p => p.Id == id);
        }

        public async Task<List<Room>> GetRoom()
        {
            return await _roomRepository.GetListAsync();
        }

        public Room GetRoomById(Guid id)
        {
            return _roomRepository.FirstOrDefault(p =>p.Id == id);
        }

        public List<Room> SearchRoom(string searchString)
        {
            return _roomRepository
                .Where(p =>
                    p.Name.Contains(searchString)
                    ).ToList();
        }

        public async Task UpdateRoom(Guid id, Room updateRoom)
        {
            var room = _roomRepository.FirstOrDefault(p => p.Id == id);
            if (room == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, SaleManagementDomainErrorCodes.ROOM_NOT_FOUND);
            }

            var sameNameRoom = _roomRepository.FirstOrDefault(p => p.Name.ToLower() == updateRoom.Name.ToLower());

            if (sameNameRoom != null && sameNameRoom.Id != id)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, SaleManagementDomainErrorCodes.ROOM_NAME_IS_TAKEN);
            }
            else
            {
                room.Name = updateRoom.Name;
                room.Price = updateRoom.Price;
                room.Status = updateRoom.Status;
                await _roomRepository.UpdateAsync(room);
            }
        }
    }
}
