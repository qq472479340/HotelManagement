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
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeService _roomTypeService;

        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddRoomType([FromBody] RoomTypeRequestModel model)
        {
            var roomType = await _roomTypeService.CreateRoomType(model);
            return Ok(roomType);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteRoomType(int id)
        {
            var roomType = await _roomTypeService.DeleteRoomType(id);
            if(roomType == null)
            {
                return BadRequest("Not Found Room Type");
            }
            return Ok(roomType);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetRoomTypeById(int id)
        {
            var roomType = await _roomTypeService.GetRoomTypeById(id);
            if(roomType == null)
            {
                return NotFound("Not Found Room Type");
            }
            return Ok(roomType);
        }

        [HttpGet]
        public async Task<IActionResult> ListAllRoomType()
        {
            var roomTypes = await _roomTypeService.ListAllRoomType();
            if (!roomTypes.Any())
            {
                return NotFound("Not Found Room Type");
            }
            return Ok(roomTypes);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoomType([FromBody] RoomTypeRequestModel model)
        {
            var roomType = await _roomTypeService.UpdateRoomType(model);
            if(roomType == null)
            {
                return BadRequest("Not Found Room Type");
            }
            return Ok(roomType);
        }

    }
}
