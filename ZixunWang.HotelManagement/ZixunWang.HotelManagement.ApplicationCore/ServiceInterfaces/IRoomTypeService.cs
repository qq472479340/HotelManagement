using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZixunWang.HotelManagement.ApplicationCore.Entities;
using ZixunWang.HotelManagement.ApplicationCore.Models;

namespace ZixunWang.HotelManagement.ApplicationCore.ServiceInterfaces
{
    public interface IRoomTypeService
    {
        Task<RoomTypeRequestModel> CreateRoomType(RoomTypeRequestModel model);
        Task<RoomTypeRequestModel> UpdateRoomType(RoomTypeRequestModel model);
        Task<RoomTypeRequestModel> DeleteRoomType(int id);
        Task<List<RoomTypeRequestModel>> ListAllRoomType();
        Task<RoomTypeRequestModel> GetRoomTypeById(int id);
    }
}
