using CRM.api.Dtos;
using CRM.Db;
using Microsoft.AspNetCore.Mvc;

namespace CRM.api.Services
{
    public interface IProjectService
    {
        public Task<IList<ProjectDto>> GetAllProjectsAsync();

        public Task<ProjectDto> AddProjectAsync(ProjectDto projectDto);

        public Task<ProjectDto> EditProjectAsync(ProjectDto editedProjectDto);

        public Task<bool> DeleteProjectAsync(int projectId);
    }
}
