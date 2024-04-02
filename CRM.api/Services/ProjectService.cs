using CRM.api.Dtos;
using CRM.api.Extensions;
using CRM.Db;
using Microsoft.EntityFrameworkCore;
using System;

namespace CRM.api.Services
{
    public class ProjectService : IProjectService
    {
        private readonly CRMDbContext _db;

        public ProjectService(CRMDbContext dbContext)
        {
            _db = dbContext;
        }


        public async Task<IList<ProjectDto>> GetAllProjectsAsync()
        {
            var allProjects = await _db.Projects.ToListAsync();
            return allProjects.ToDto();
        }

        public async Task<ProjectDto> AddProjectAsync(ProjectDto projectDto)
        {
            var newProject = new Project
            {
                ProjectId = projectDto.ProjectId,
                Status = projectDto.Status,
                Budget = projectDto.Budget,
                lastUpdated = projectDto.lastUpdated,
                Notes = projectDto.Notes,
                startDate = projectDto.startDate,
                endDate = projectDto.endDate
                // Populate other properties as needed
            };

            // Add the new project to the database
            _db.Projects.Add(newProject);

            // Save changes asynchronously
            await _db.SaveChangesAsync();

            // Convert the added project entity to a ProjectDto and return it
            return newProject.ToDto();
        }


        public async Task<ProjectDto> EditProjectAsync(ProjectDto editedProjectDto)
        {
            // Retrieve the existing project from the database
            var existingProject = await _db.Projects.FindAsync(editedProjectDto.Id);

            if (existingProject == null)
            {
                // Handle the case where the project doesn't exist
                throw new ArgumentException("Project not found", nameof(editedProjectDto.Id));
            }

            // Update the properties of the existing project entity based on the editedProjectDto
            existingProject.ProjectId = editedProjectDto.ProjectId;
            existingProject.Status = editedProjectDto.Status;
            existingProject.Budget = editedProjectDto.Budget;
            existingProject.lastUpdated = editedProjectDto.lastUpdated;
            existingProject.Notes = editedProjectDto.Notes;
            existingProject.startDate = editedProjectDto.startDate;
            existingProject.endDate = editedProjectDto.endDate;
            // Update other properties as needed

            // Save changes asynchronously
            await _db.SaveChangesAsync();

            // Convert the updated project entity to a ProjectDto and return it
            return existingProject.ToDto();
        }

        public async Task<bool> DeleteProjectAsync(int projectId)
        {
            // Retrieve the existing project from the database
            var existingProject = await _db.Projects.FindAsync(projectId);

            if (existingProject == null)
            {
                // Handle the case where the project doesn't exist
                return false;
            }

            // Remove the project from the context
            _db.Projects.Remove(existingProject);

            try
            {
                // Save changes asynchronously
                await _db.SaveChangesAsync();
                return true; // Return true indicating successful deletion
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency issues
                // For example, another user might have deleted the entity
                return false;
            }
        }
    }
}
