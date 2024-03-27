using CRM.api.Dtos;
using CRM.Db;
using Microsoft.AspNetCore.Mvc;

namespace CRM.api.Services
{
    public interface ICustomerService 
    {
        public Task<IList<CustomerDto>> GetAllCustomersAsync();
        
        public Task<CustomerDto> AddCustomerAsync(CustomerDto customerDto);

        public Task<CustomerDto> EditCustomerAsync(CustomerDto editedCustomerDto);

        public Task<bool> DeleteCustomerAsync(int customerId);
    }
}
