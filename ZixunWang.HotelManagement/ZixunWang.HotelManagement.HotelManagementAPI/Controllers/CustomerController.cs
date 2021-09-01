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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerRequestModel model)
        {
            var customer = await _customerService.CreateCustomer(model);
            return Ok(customer);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _customerService.DeleteCustomer(id);
            if (customer == null)
            {
                return BadRequest("Not Found Customer");
            }
            return Ok(customer);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound("Not Found Customer");
            }
            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> ListAllCustomer()
        {
            var customers = await _customerService.ListAllCustomer();
            if (!customers.Any())
            {
                return NotFound("Not Found Customer");
            }
            return Ok(customers);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerRequestModel model)
        {
            var customer = await _customerService.UpdateCustomer(model);
            if (customer == null)
            {
                return BadRequest("Not Found Customer");
            }
            return Ok(customer);
        }
    }
}