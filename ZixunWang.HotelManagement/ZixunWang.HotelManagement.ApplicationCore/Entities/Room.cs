using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZixunWang.HotelManagement.ApplicationCore.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int? RoomTypeId { get; set; }
        public bool? Status { get; set; }

        public RoomType RoomType { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
