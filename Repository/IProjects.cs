using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeReportProject.Areas.Identity.Data;
using TimeReportProject.Models;

namespace TimeReportProject.Repository
{
   public interface IProjects
    {
        List<Project> GetAllProjects();
        List<SelectListItem> GetProjectForList();
        Project GetProjectByID(int? id);
        bool AddProjectDetails(Project project);
        bool UpdateProjectDetails(Project project);

        public string ErrorMessage { get; set; }
    }

   public interface IConsultantSchedule
    {
        bool AddScheduleDetails(ConsultantProject  consultantProject );
        string GetConsultantNameByID(string ID);
        List<MonthWise> GetMonthWiseDetails(int? ProjectID=0,int? MonthID=0, int? YearID=0, string? UserID="");
        public string ErrorMessage { get; set; }
        public List<TimeReportProjectUser> GetUsers();

       public List<ConsultantProject> GetDateWiseDetails(string? UserId,int? MonthID,int? YearID,DateTime? DateOfSchedule=null);

    }
}
