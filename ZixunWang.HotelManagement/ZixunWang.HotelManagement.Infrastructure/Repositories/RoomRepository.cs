using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZixunWang.HotelManagement.ApplicationCore.Entities;
using ZixunWang.HotelManagement.ApplicationCore.RepositoryInterfaces;
using ZixunWang.HotelManagement.Infrastructure.Data;

namespace ZixunWang.HotelManagement.Infrastructure.Repositories
{
    public class RoomRepository : EfRepository<Room>, IRoomRepository
    {
        public RoomRepository(HotelManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Room> GetAllInformationById(int id)
        {
            var room = await _dbContext.Rooms.Include(r => r.RoomType).FirstOrDefaultAsync(c => c.Id == id);
            if (room == null)
            {
                throw new Exception("No customer found");
            }
            return room;
        }
    }
}
