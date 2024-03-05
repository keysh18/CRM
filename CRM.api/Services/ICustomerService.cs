using CRM.api.Dtos;
using CRM.Db;
using Microsoft.AspNetCore.Mvc;

namespace CRM.api.Services
{
    public interface ICustomerService 
    {
        public Task<CustomerDto> GetAllCustomersAsync();
    }

}
