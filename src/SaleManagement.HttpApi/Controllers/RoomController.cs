using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaleManagement.Controllers
{
    [Route("api/room")]
    [ApiController]
    public class RoomController : SaleManagementController
    {
        private readonly IRoomAppService _roomAppService;

        public RoomController(IRoomAppService roomAppService)
        {
            _roomAppService = roomAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<RoomDto>> GetRoom()
        {
            var room = await _roomAppService.GetRoom();
            return room;
        }


        [HttpGet("{id}")]
        public RoomDto GetRoomById([FromRoute] Guid id)
        {
            return _roomAppService.GetRoomById(id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(CreateUpdateRoomDto input)
        {
            await _roomAppService.CreateRoom(input);
            return Ok("Create Room Successfully.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(Guid id)
        {
            await _roomAppService.DeleteRoom(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(Guid id, CreateUpdateRoomDto input)
        {
            await _roomAppService.UpdateRoom(id, input);
            return Ok();
        }

        [HttpGet("{value}/search")]
        public List<RoomDto> SearchRoom(string value)

        {
            var roomSearch = _roomAppService.SearchRoom(value);
            return roomSearch;
        }
    }
}
