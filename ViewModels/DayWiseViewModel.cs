using Microsoft.AspNetCore.Mvc.Rendering;
using TimeReportProject.Models;

namespace TimeReportProject.ViewModels
{
    public class DayWiseViewModel
    {
        public List<ConsultantProject> DayWiseDetails { get; set; }
        public string UserID { get; set; }
        public List<SelectListItem> Users { get; set; }

        public List<SelectListItem> Months { get; set; }
        public int MonthID { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public Pager Pager { get; set; }

    }
}
