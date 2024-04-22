using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Db
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Company { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int status { get; set; }

        public string Budget { get; set; }

        public string Project { get; set; }

        public string LastUpdated { get; set; }

        public string Notes { get; set; }
    }
}
