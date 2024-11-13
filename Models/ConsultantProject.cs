using System.ComponentModel.DataAnnotations;
using TimeReportProject.Areas.Identity.Data;

namespace TimeReportProject.Models
{
    public class ConsultantProject
    {
      
            public int? ProjectID { get; set; }
            public Project Project { get; set; }
            public string? UserID { get; set; }  // The Consultant..
            public TimeReportProjectUser  User { get; set; }
            [DataType(DataType.Date)]
            public DateTime? EntryDate { get; set; }

            public DateTime? StartTime { get; set; }
            public DateTime? EndTime { get; set; }
            public DateTime? StartLunchTime { get; set; }
            public DateTime? EndLunchTime { get; set; }
            public string? Comments { get; set; }


        }

    }

