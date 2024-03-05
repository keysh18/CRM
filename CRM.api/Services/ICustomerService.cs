using CRM.api.Dtos;
using CRM.Db;
using Microsoft.AspNetCore.Mvc;

namespace CRM.api.Services
{
    public interface ICustomerService 
    {
        public Task<IList<CustomerDto>> GetAllCustomersAsync();
        
        public Task<CustomerDto> AddCustomerAsync();

        public Task<CustomerDto> EditCustomerAsync();

        public Task<bool> DeleteCustomerAsync();
    }
}
