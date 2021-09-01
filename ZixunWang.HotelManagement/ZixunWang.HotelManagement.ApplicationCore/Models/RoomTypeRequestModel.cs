using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZixunWang.HotelManagement.ApplicationCore.Models
{
    public class RoomTypeRequestModel
    {
        public int Id { get; set; }
        public string RTDESC { get; set; }
        public decimal? Rent { get; set; }
    }
}
