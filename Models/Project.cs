using System.ComponentModel.DataAnnotations;
using TimeReportProject.Areas.Identity.Data;

namespace TimeReportProject.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        [Required]
        public string ProjectName { get; set; }
        public string ? ProjectDesc { get; set; }

        public ICollection<ConsultantProject > ConsultantProjects  { get; set; }


    }
}
