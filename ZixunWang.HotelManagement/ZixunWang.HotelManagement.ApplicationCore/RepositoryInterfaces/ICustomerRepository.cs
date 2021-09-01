using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZixunWang.HotelManagement.ApplicationCore.Entities;

namespace ZixunWang.HotelManagement.ApplicationCore.RepositoryInterfaces
{
    public interface ICustomerRepository: IAsyncRepository<Customer>
    {
        Task<Customer> GetAllInformationById(int id);
    }
}
