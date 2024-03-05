using CRM.api.Dtos;
using CRM.Db;

namespace CRM.api.Extensions;

public static class DtoExtensions
{
    public static CustomerDto ToDto(this Customer customer)
    {
        return new CustomerDto()
        {
            Name = customer.Name,
            Email = customer.Email
            //TODO: Add additional properties here.
        };
    }
    
    public static IList<CustomerDto> ToDto(this IList<Customer> customers)
    {
        return customers.Select(customer => customer.ToDto()).ToList();
    }
}