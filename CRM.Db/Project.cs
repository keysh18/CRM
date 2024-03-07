using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Db
{
    public class Project
    {
        [ForeignKey("Customer")]
        public int Id { get; set; }

        [Key]
        public int ProjectId { get; set; }

        public int Status { get; set; }

        public float Budget { get; set; }

        public DateTime lastUpdated { get; set; }

        public string Notes { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }
    }
}
