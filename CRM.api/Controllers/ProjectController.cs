using CRM.api.Dtos;
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
        public async Task<IActionResult> AddNewProjectAsync([FromBody] ProjectDto newProject)
        {
            var project = await _projectService.AddProjectAsync(newProject);
            return Ok(project);
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EditProjectAsync([FromBody] ProjectDto editedProjectDto)
        {
            var project = await _projectService.EditProjectAsync(editedProjectDto);
            return Ok(project);
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public async Task<IActionResult> RemoveProjectAsync([FromRoute] int id)
        {
            var success = await _projectService.DeleteProjectAsync(id);
            return Ok(success);
        }
    }

}
