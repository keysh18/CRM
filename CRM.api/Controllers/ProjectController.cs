using CRM.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRM.api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllProjectsAsync()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddNewProjectAsync()
        {
            return Ok();
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EditProjectAsync()
        {
            return Ok();
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public async Task<IActionResult> RemoveProjectAsync([FromRoute] string id)
        {
            return Ok();
        }
    }

}
