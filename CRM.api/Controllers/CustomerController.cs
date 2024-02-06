using Microsoft.AspNetCore.Mvc;

namespace CRM.api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CustomerController: ControllerBase
    {
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            return Ok();
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
