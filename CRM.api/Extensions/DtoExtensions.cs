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
}