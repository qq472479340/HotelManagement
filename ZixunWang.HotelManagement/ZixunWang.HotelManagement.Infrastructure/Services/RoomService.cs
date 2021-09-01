using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZixunWang.HotelManagement.ApplicationCore.Entities;
using ZixunWang.HotelManagement.ApplicationCore.Models;
using ZixunWang.HotelManagement.ApplicationCore.RepositoryInterfaces;
using ZixunWang.HotelManagement.ApplicationCore.ServiceInterfaces;

namespace ZixunWang.HotelManagement.Infrastructure.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<RoomRequestModel> CreateRoom(RoomRequestModel model)
        {
            var room = new Room { RoomTypeId = model.RoomTypeId, Status = model.Status };
            var createdRoom = await _roomRepository.AddAsync(room);
            var result = new RoomRequestModel
            {
                Id = createdRoom.Id,
                RoomTypeId = createdRoom.RoomTypeId,
                Status = createdRoom.Status
            };
            return result;
        }

        public async Task<RoomRequestModel> DeleteRoom(int id)
        {
            var exist = await _roomRepository.GetExistsAsync(r => r.Id == id);
            if (!exist)
            {
                throw new Exception($"Not Found Room For Id={id}");
            }
            var room = await _roomRepository.GetByIdAsync(id);
            var deletedRoom = await _roomRepository.DeleteAsync(room);
            var result = new RoomRequestModel
            {
                Id = deletedRoom.Id,
                RoomTypeId = deletedRoom.RoomTypeId,
                Status = deletedRoom.Status
            };
            return result;
        }

        public async Task<RoomDetailsResponseModel> GetRoomById(int id)
        {
            var exist = await _roomRepository.GetExistsAsync(r => r.Id == id);
            if (!exist)
            {
                throw new Exception($"Not Found Room For Id ={ id }");
            }
            var room = await _roomRepository.GetAllInformationById(id);
            var result = new RoomDetailsResponseModel
            {
                Id = room.Id,
                RoomTypeId = room.RoomTypeId,
                Status = room.Status
            };
            result.RoomType = new RoomTypeRequestModel
            {
                Id = room.RoomType.Id,
                RTDESC = room.RoomType.RTDESC,
                Rent = room.RoomType.Rent
            };
            return result;
        }

        public async Task<List<RoomRequestModel>> ListAllRoom()
        {
            var rooms = await _roomRepository.ListAllAsync();
            var results = new List<RoomRequestModel>();
            foreach (var room in rooms)
            {
                var _room = new RoomRequestModel
                {
                    Id = room.Id,
                    RoomTypeId = room.RoomTypeId,
                    Status = room.Status
                };
                results.Add(_room);
            }
            return results;
        }

        public async Task<RoomRequestModel> UpdateRoom(RoomRequestModel model)
        {
            var exist = await _roomRepository.GetExistsAsync(r => r.Id == model.Id);
            if (!exist)
            {
                throw new Exception($"Not Found Room For Id ={ model.Id }");
            }
            var room = new Room { Id = model.Id, RoomTypeId = model.RoomTypeId, Status = model.Status };
            var updatedRoom = await _roomRepository.UpdateAsync(room);
            return model;
        }
    }
}
