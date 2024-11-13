using System.ComponentModel.DataAnnotations.Schema;

namespace TimeReportProject.Models
{
    [NotMapped]
    public class MonthWise
    {
        public int Month { get; set; }
        public string ProjectName { get; set; }
        public string MonthName{get;set;}
        public string? UserID { get;set;}
        public string ConsultantName { get; set;}
        public string? NoOfHours { get; set; }
        

    }
}
