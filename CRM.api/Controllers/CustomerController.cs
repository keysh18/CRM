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
        public async Task<IActionResult> AddNewCustomerAsync()
        {
            return Ok();
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EditCustomerAsync()
        {
            return Ok();
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public async Task<IActionResult> RemoveCustomerAsync([FromRoute] string id)
        {
            return Ok();
        }
    }

}
