﻿using System;
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

        public virtual List<Project> Projects { get; set; }
    }
}
