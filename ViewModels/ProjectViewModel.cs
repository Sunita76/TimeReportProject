using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using TimeReportProject.Models;

namespace TimeReportProject.ViewModels
{
    public class ProjectViewModel
    {
       public List<Project>? Projects { get; set; }
    [Required( ErrorMessage="Enter the Project Name")]
        public string ProjectName { get; set; }
        public string? ProjectDesc { get; set; }
        public int? ProjectID { get; set; }
    }
}
