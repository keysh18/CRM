using CRM.api.Dtos;
using CRM.api.Extensions;
using CRM.Db;
using Microsoft.EntityFrameworkCore;
using System;

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

        public Task<CustomerDto> AddCustomerAsync(CustomerDto customerDto)
        {
            var newCustomer = new Customer
            {
                Name = customerDto.Name,
                Email = customerDto.Email,
                Company = customerDto.Company,
                PhoneNumber = customerDto.PhoneNumber
                // Populate other properties as needed
            };

            // Add the new customer to the database
            _db.Customers.Add(newCustomer);

            // Save changes asynchronously
            await _db.SaveChangesAsync();

            // Convert the added customer entity to a CustomerDto and return it
            return newCustomer.ToDto();
        }

        public Task<CustomerDto> EditCustomerAsync(int customerId, CustomerDto editedCustomerDto)
        {
            // Retrieve the existing customer from the database
            var existingCustomer = await _db.Customers.FindAsync(customerId);

            if (existingCustomer == null)
            {
                // Handle the case where the customer doesn't exist
                throw new ArgumentException("Customer not found", nameof(customerId));
            }

            // Update the properties of the existing customer entity based on the editedCustomerDto
            existingCustomer.Name = editedCustomerDto.Name;
            existingCustomer.Email = editedCustomerDto.Email;
            existingCustomer.Company = editedCustomerDto.Company;
            existingCustomer.PhoneNumber = editedCustomerDto.PhoneNumber;
            // Update other properties as needed

            // Save changes asynchronously
            await _db.SaveChangesAsync();

            // Convert the updated customer entity to a CustomerDto and return it
            return existingCustomer.ToDto();
        }

        public Task<bool> DeleteCustomerAsync(int customerId)
        {
            // Retrieve the existing customer from the database
            var existingCustomer = await _db.Customers.FindAsync(customerId);

            if (existingCustomer == null)
            {
                // Handle the case where the customer doesn't exist
                return false;
            }

            // Remove the customer from the context
            _db.Customers.Remove(existingCustomer);

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
