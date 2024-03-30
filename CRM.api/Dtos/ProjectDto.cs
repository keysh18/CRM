using CRM.Db;
using static Azure.Core.HttpHeader;

namespace CRM.api.Dtos
{
    public class ProjectDto
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int Status { get; set; }

        public float Budget { get; set; }

        public DateTime lastUpdated { get; set; }

        public string Notes { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }
    }
}

