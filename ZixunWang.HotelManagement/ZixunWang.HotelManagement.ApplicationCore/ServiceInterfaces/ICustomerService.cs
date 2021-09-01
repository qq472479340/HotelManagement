using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZixunWang.HotelManagement.ApplicationCore.Entities;
using ZixunWang.HotelManagement.ApplicationCore.Models;

namespace ZixunWang.HotelManagement.ApplicationCore.ServiceInterfaces
{
    public interface ICustomerService
    {
        Task<CustomerRequestModel> CreateCustomer(CustomerRequestModel model);
        Task<CustomerRequestModel> UpdateCustomer(CustomerRequestModel model);
        Task<CustomerRequestModel> DeleteCustomer(int id);
        Task<List<CustomerRequestModel>> ListAllCustomer();
        Task<CustomerDetailsResponseModel> GetCustomerById(int id);
    }
}
