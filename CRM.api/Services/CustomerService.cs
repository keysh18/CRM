using CRM.api.Dtos;
using CRM.api.Extensions;
using CRM.Db;
using Microsoft.EntityFrameworkCore;

namespace CRM.api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CRMDbContext _db;
        
        public CustomerService(CRMDbContext dbContext)
        {
            _db = dbContext;
        }
        
        public async Task<IList<CustomerDto>> GetAllCustomersAsync()
        {
            var allUsers = await _db.Customers.ToListAsync();
            return allUsers.ToDto();
        }

        public Task<CustomerDto> AddCustomerAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDto> EditCustomerAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCustomerAsync()
        {
            throw new NotImplementedException();
        }
    }
}
