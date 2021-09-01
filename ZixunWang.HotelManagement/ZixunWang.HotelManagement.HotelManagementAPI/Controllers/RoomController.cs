using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZixunWang.HotelManagement.ApplicationCore.Models;
using ZixunWang.HotelManagement.ApplicationCore.ServiceInterfaces;

namespace ZixunWang.HotelManagement.HotelManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom([FromBody] RoomRequestModel model)
        {
            var room = await _roomService.CreateRoom(model);
            return Ok(room);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _roomService.DeleteRoom(id);
            if (room == null)
            {
                return BadRequest("Not Found Room");
            }
            return Ok(room);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = await _roomService.GetRoomById(id);
            if (room == null)
            {
                return NotFound("Not Found Room");
            }
            return Ok(room);
        }

        [HttpGet]
        public async Task<IActionResult> ListAllRoom()
        {
            var rooms = await _roomService.ListAllRoom();
            if (!rooms.Any())
            {
                return NotFound("Not Found Room");
            }
            return Ok(rooms);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoom([FromBody] RoomRequestModel model)
        {
            Console.WriteLine(model);
            var room = await _roomService.UpdateRoom(model);
            if (room == null)
            {
                return BadRequest("Not Found Room");
            }
            return Ok(room);
        }
    }
}
