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
    public class ServiceService : IServiceService
    {
        private readonly IAsyncRepository<Service> _serviceRepository;
        public ServiceService(IAsyncRepository<Service> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task<ServiceRequestModel> CreateService(ServiceRequestModel model)
        {
            var service = new Service { RoomId = model.RoomId, SDESC = model.SDESC, Amount = model.Amount, ServiceDate = model.ServiceDate };
            var createdService = await _serviceRepository.AddAsync(service);
            var result = new ServiceRequestModel
            {
                Id = createdService.Id,
                RoomId = createdService.RoomId,
                SDESC = createdService.SDESC,
                Amount = createdService.Amount,
                ServiceDate = createdService.ServiceDate
            };
            return result;
        }

        public async Task<ServiceRequestModel> DeleteService(int id)
        {
            var exist = await _serviceRepository.GetExistsAsync(s => s.Id == id);
            if (!exist)
            {
                throw new Exception($"Not Found Service For Id={id}");
            }
            var service = await _serviceRepository.GetByIdAsync(id);
            var deletedService = await _serviceRepository.DeleteAsync(service);
            var result = new ServiceRequestModel
            {
                Id = deletedService.Id,
                RoomId = deletedService.RoomId,
                SDESC = deletedService.SDESC,
                Amount = deletedService.Amount,
                ServiceDate = deletedService.ServiceDate
            };
            return result;
        }

        public async Task<ServiceRequestModel> GetServiceById(int id)
        {
            var exist = await _serviceRepository.GetExistsAsync(s => s.Id == id);
            if (!exist)
            {
                throw new Exception($"Not Found Service For Id={id}");
            }
            var service = await _serviceRepository.GetByIdAsync(id);
            var result = new ServiceRequestModel
            {
                Id = service.Id,
                RoomId = service.RoomId,
                SDESC = service.SDESC,
                Amount = service.Amount,
                ServiceDate = service.ServiceDate
            };
            return result;
        }

        public async Task<List<ServiceRequestModel>> ListAllService()
        {
            var services = await _serviceRepository.ListAllAsync();
            var results = new List<ServiceRequestModel>();
            foreach (var service in services)
            {
                var _service = new ServiceRequestModel
                {
                    Id = service.Id,
                    RoomId = service.RoomId,
                    SDESC = service.SDESC,
                    Amount = service.Amount,
                    ServiceDate = service.ServiceDate
                };
                results.Add(_service);
            }
            return results;
        }

        public async Task<ServiceRequestModel> UpdateService(ServiceRequestModel model)
        {
            var exist = await _serviceRepository.GetExistsAsync(s => s.Id == model.Id);
            if (!exist)
            {
                throw new Exception($"Not Found Service For Id={model.Id}");
            }
            var service = new Service { Id = model.Id, RoomId = model.RoomId, SDESC = model.SDESC, Amount = model.Amount, ServiceDate = model.ServiceDate };
            var updatedService = await _serviceRepository.UpdateAsync(service);
            return model;
        }
    }
}
