using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZixunWang.HotelManagement.ApplicationCore.Models;
using ZixunWang.HotelManagement.ApplicationCore.ServiceInterfaces;

namespace ZixunWang.HotelManagement.HotelManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpPost]
        public async Task<IActionResult> AddService([FromBody] ServiceRequestModel model)
        {
            var service = await _serviceService.CreateService(model);
            return Ok(service);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _serviceService.DeleteService(id);
            if (service == null)
            {
                return BadRequest("Not Found Service");
            }
            return Ok(service);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var service = await _serviceService.GetServiceById(id);
            if (service == null)
            {
                return NotFound("Not Found Room Type");
            }
            return Ok(service);
        }

        [HttpGet]
        public async Task<IActionResult> ListAllService()
        {
            var services = await _serviceService.ListAllService();
            if (!services.Any())
            {
                return NotFound("Not Found Service");
            }
            return Ok(services);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService([FromBody] ServiceRequestModel model)
        {
            var service = await _serviceService.UpdateService(model);
            if (service == null)
            {
                return BadRequest("Not Found Service");
            }
            return Ok(service);
        }
    }
}
