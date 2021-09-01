using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZixunWang.HotelManagement.ApplicationCore.Entities;
using ZixunWang.HotelManagement.ApplicationCore.Models;

namespace ZixunWang.HotelManagement.ApplicationCore.ServiceInterfaces
{
    public interface IServiceService
    {
        Task<ServiceRequestModel> CreateService(ServiceRequestModel model);
        Task<ServiceRequestModel> UpdateService(ServiceRequestModel model);
        Task<ServiceRequestModel> DeleteService(int id);
        Task<List<ServiceRequestModel>> ListAllService();
        Task<ServiceRequestModel> GetServiceById(int id);
    }
}
