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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<CustomerRequestModel> CreateCustomer(CustomerRequestModel model)
        {
            var customer = new Customer
            {
                RoomId = model.RoomId,
                CName = model.CName,
                Address = model.Address,
                Phone = model.Phone,
                Email = model.Email,
                CheckIn = model.CheckIn,
                TotalPersons = model.TotalPersons,
                BookingDays = model.BookingDays,
                Advance = model.Advance
            };
            var createdCustomer = await _customerRepository.AddAsync(customer);
            var result = new CustomerRequestModel
            {
                Id = createdCustomer.Id,
                RoomId = createdCustomer.RoomId,
                CName = createdCustomer.CName,
                Address = createdCustomer.Address,
                Phone = createdCustomer.Phone,
                Email = createdCustomer.Email,
                CheckIn = createdCustomer.CheckIn,
                TotalPersons = createdCustomer.TotalPersons,
                BookingDays = createdCustomer.BookingDays,
                Advance = createdCustomer.Advance
            };
            return result;
        }

        public async Task<CustomerRequestModel> DeleteCustomer(int id)
        {
            var exist = await _customerRepository.GetExistsAsync(c => c.Id == id);
            if (!exist)
            {
                throw new Exception($"Not Found Customer For Id={id}");
            }
            var customer = await _customerRepository.GetByIdAsync(id);
            var deletedCustomer = await _customerRepository.DeleteAsync(customer);
            var result = new CustomerRequestModel
            {
                Id = deletedCustomer.Id,
                RoomId = deletedCustomer.RoomId,
                CName = deletedCustomer.CName,
                Address = deletedCustomer.Address,
                Phone = deletedCustomer.Phone,
                Email = deletedCustomer.Email,
                CheckIn = deletedCustomer.CheckIn,
                TotalPersons = deletedCustomer.TotalPersons,
                BookingDays = deletedCustomer.BookingDays,
                Advance = deletedCustomer.Advance
            };
            return result;
        }

        public async Task<CustomerDetailsResponseModel> GetCustomerById(int id)
        {
            var exist = await _customerRepository.GetExistsAsync(c => c.Id == id);
            if (!exist)
            {
                throw new Exception($"Not Found Customer For Id={id}");
            }
            var customer = await _customerRepository.GetAllInformationById(id);
            var result = new CustomerDetailsResponseModel
            {
                Id = customer.Id,
                RoomId = customer.RoomId,
                CName = customer.CName,
                Address = customer.Address,
                Phone = customer.Phone,
                Email = customer.Email,
                CheckIn = customer.CheckIn,
                TotalPersons = customer.TotalPersons,
                BookingDays = customer.BookingDays,
                Advance = customer.Advance
            };
            result.Room = new RoomServiceResponseModel
            {
                Id = customer.Room.Id,
                RoomTypeId = customer.Room.RoomTypeId,
                Status = customer.Room.Status
            };
            result.Room.Services = new List<ServiceRequestModel>();
            foreach (var service in customer.Room.Services)
            {
                var _service = new ServiceRequestModel
                {
                    Id = service.Id,
                    Amount = service.Amount,
                    RoomId = service.RoomId,
                    SDESC = service.SDESC,
                    ServiceDate = service.ServiceDate
                };
                result.Room.Services.Add(_service);
            }
            return result;
        }

        public async Task<List<CustomerRequestModel>> ListAllCustomer()
        {
            var customers = await _customerRepository.ListAllAsync();
            var results = new List<CustomerRequestModel>();
            foreach (var customer in customers)
            {
                var _customer = new CustomerRequestModel
                {
                    Id = customer.Id,
                    RoomId = customer.RoomId,
                    CName = customer.CName,
                    Address = customer.Address,
                    Phone = customer.Phone,
                    Email = customer.Email,
                    CheckIn = customer.CheckIn,
                    TotalPersons = customer.TotalPersons,
                    BookingDays = customer.BookingDays,
                    Advance = customer.Advance
                };
                results.Add(_customer);
            }
            return results;
        }

        public async Task<CustomerRequestModel> UpdateCustomer(CustomerRequestModel model)
        {
            var exist = await _customerRepository.GetExistsAsync(c => c.Id == model.Id);
            if (!exist)
            {
                throw new Exception($"Not Found Customer For Id={model.Id}");
            }
            var customer = new Customer
            {
                Id = model.Id,
                RoomId = model.RoomId,
                CName = model.CName,
                Address = model.Address,
                Phone = model.Phone,
                Email = model.Email,
                CheckIn = model.CheckIn,
                TotalPersons = model.TotalPersons,
                BookingDays = model.BookingDays,
                Advance = model.Advance
            };
            var updatedCustomer = await _customerRepository.UpdateAsync(customer);
            return model;
        }
    }
}
