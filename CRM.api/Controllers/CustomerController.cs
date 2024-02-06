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


    }

}
