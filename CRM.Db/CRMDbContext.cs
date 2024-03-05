using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CRM.Db
{
    public class CRMDbContext: DbContext
    {
        public CRMDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }

    }
}
