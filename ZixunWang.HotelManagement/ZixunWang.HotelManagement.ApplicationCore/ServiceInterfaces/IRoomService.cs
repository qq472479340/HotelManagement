using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZixunWang.HotelManagement.ApplicationCore.Entities;
using ZixunWang.HotelManagement.ApplicationCore.Models;

namespace ZixunWang.HotelManagement.ApplicationCore.ServiceInterfaces
{
    public interface IRoomService
    {
        Task<RoomRequestModel> CreateRoom(RoomRequestModel model);
        Task<RoomRequestModel> UpdateRoom(RoomRequestModel model);
        Task<RoomRequestModel> DeleteRoom(int id);
        Task<List<RoomRequestModel>> ListAllRoom();
        Task<RoomDetailsResponseModel> GetRoomById(int id);
    }
}
