using CRM.api.Dtos;
using CRM.Db;

namespace CRM.api.Extensions;

public static class DtoExtensions
{
    public static CustomerDto ToDto(this Customer customer)
    {
        return new CustomerDto()
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            Company = customer.Company,
            PhoneNumber = customer.PhoneNumber
            //TODO: Add additional properties here.
        };
    }
    
    public static IList<CustomerDto> ToDto(this IList<Customer> customers)
    {
        return customers.Select(customer => customer.ToDto()).ToList();
    }

    public static ProjectDto ToDto(this Project project)
    {
        return new ProjectDto()
        {
            Id = project.Id,
            ProjectId = project.ProjectId,
            Status = project.Status,
            Budget = project.Budget,
            lastUpdated = project.lastUpdated,
            Notes = project.Notes,
            startDate = project.startDate,
            endDate = project.endDate,
            //TODO: Add additional properties here.
        };
    }

    public static IList<ProjectDto> ToDto(this IList<Project> projects)
    {
        return projects.Select(project => project.ToDto()).ToList();
    }
}