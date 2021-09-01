using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZixunWang.HotelManagement.ApplicationCore.Models
{
    public class RoomDetailsResponseModel
    {
        public int Id { get; set; }
        public int? RoomTypeId { get; set; }
        public bool? Status { get; set; }

        public RoomTypeRequestModel RoomType { get; set; }
    }
}
