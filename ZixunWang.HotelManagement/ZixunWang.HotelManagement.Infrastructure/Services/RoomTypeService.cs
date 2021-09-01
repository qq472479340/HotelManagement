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
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IAsyncRepository<RoomType> _roomTypeRepository;
        public RoomTypeService(IAsyncRepository<RoomType> roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }
        public async Task<RoomTypeRequestModel> CreateRoomType(RoomTypeRequestModel model)
        {
            var roomType = new RoomType { RTDESC = model.RTDESC, Rent = model.Rent };
            var createdRoomType = await _roomTypeRepository.AddAsync(roomType);
            var result = new RoomTypeRequestModel
            {
                Id = createdRoomType.Id,
                RTDESC = createdRoomType.RTDESC,
                Rent = createdRoomType.Rent
            };
            return result;
        }

        public async Task<RoomTypeRequestModel> DeleteRoomType(int id)
        {
            var exist = await _roomTypeRepository.GetExistsAsync(rt => rt.Id == id);
            if (!exist)
            {
                throw new Exception($"Not Found Room Type For Id={id}");
            }
            var roomType = await _roomTypeRepository.GetByIdAsync(id);
            var deletedRoomType = await _roomTypeRepository.DeleteAsync(roomType);
            var result = new RoomTypeRequestModel
            {
                Id = deletedRoomType.Id,
                RTDESC = deletedRoomType.RTDESC,
                Rent = deletedRoomType.Rent
            };
            return result;
        }

        public async Task<RoomTypeRequestModel> GetRoomTypeById(int id)
        {
            var exist = await _roomTypeRepository.GetExistsAsync(rt => rt.Id == id);
            if (!exist)
            {
                throw new Exception($"Not Found Room Type For Id={id}");
            }
            var roomType = await _roomTypeRepository.GetByIdAsync(id);
            var result = new RoomTypeRequestModel
            {
                Id = roomType.Id,
                RTDESC = roomType.RTDESC,
                Rent = roomType.Rent
            };
            return result;
        }

        public async Task<List<RoomTypeRequestModel>> ListAllRoomType()
        {
            var roomTypes = await _roomTypeRepository.ListAllAsync();
            var results = new List<RoomTypeRequestModel>();
            foreach (var roomType in roomTypes)
            {
                var _roomType = new RoomTypeRequestModel
                {
                    Id = roomType.Id,
                    RTDESC = roomType.RTDESC,
                    Rent = roomType.Rent
                };
                results.Add(_roomType);
            }
            return results;
        }

        public async Task<RoomTypeRequestModel> UpdateRoomType(RoomTypeRequestModel model)
        {
            var exist = await _roomTypeRepository.GetExistsAsync(rt => rt.Id == model.Id);
            if (!exist)
            {
                throw new Exception($"Not Found Room Type For Id={model.Id}");
            }
            var roomType = new RoomType { Id = model.Id, RTDESC = model.RTDESC, Rent = model.Rent };
            var updatedRoomType = await _roomTypeRepository.UpdateAsync(roomType);
            return model;
        }
    }
}
