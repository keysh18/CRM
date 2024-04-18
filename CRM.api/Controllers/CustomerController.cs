using CRM.api.Dtos;
using CRM.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRM.api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CustomerController: ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddNewCustomerAsync([FromBody]CustomerDto newCustomer)
        {
            var customer = await _customerService.AddCustomerAsync(newCustomer);
            return Ok(customer);
        }

        [HttpPut]
        [Route("edit/{id}")]
        public async Task<IActionResult> EditCustomerAsync([FromBody] CustomerDto editedCustomerDto int id)
        {
            var customer = await _customerService.EditCustomerAsync(editedCustomerDto);
            return Ok(customer);
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public async Task<IActionResult> RemoveCustomerAsync([FromRoute] int id)
        {
            var success = await _customerService.DeleteCustomerAsync(id);
            return Ok(success);
        }
    }

}
