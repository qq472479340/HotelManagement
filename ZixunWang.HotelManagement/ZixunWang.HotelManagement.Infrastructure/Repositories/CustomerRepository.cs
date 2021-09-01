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
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(HotelManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Customer> GetAllInformationById(int id)
        {
            var customer = await _dbContext.Customers.Include(c => c.Room).ThenInclude(r => r.Services).FirstOrDefaultAsync(c => c.Id == id);
            if(customer == null)
            {
                throw new Exception("No customer found");
            }
            return customer;
        }
    }
}
