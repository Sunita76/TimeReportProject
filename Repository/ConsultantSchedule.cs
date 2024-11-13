
using Microsoft.EntityFrameworkCore;
using TimeReportProject.Data;
using TimeReportProject.Models;
using TimeReportProject.Areas.Identity.Data;

namespace TimeReportProject.Repository
{
    public class ConsultantSchedule : IConsultantSchedule
    {
        public string ErrorMessage { get; set; }
        private ApplicationDbContext _context { get; set; }

        public ConsultantSchedule(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool AddScheduleDetails(ConsultantProject consultantproject)
        {
            try
            {
                _context.ConsultantProjects.Add(consultantproject);
                return _context.SaveChanges() > 0;

            }
            catch (DbUpdateException ex)
            {
                ErrorMessage =  ex.InnerException.Message;
                return false;
            }
           
            catch (Exception ex)
            {
                ErrorMessage = ex.InnerException.Message;
                return false;

            }

        }
        public List<TimeReportProjectUser>  GetUsers()
        {
            return _context.Users.Where(a=>a.UserName != "admin@yahoo.co.in").ToList();
        }
        public List<MonthWise> GetMonthWiseDetails(int? ProjectId = 0,int? MonthID = 0,int? YearID=0,string? UserID="")
        {
           Dictionary<int,string> monthNames = new Dictionary<int,string>();
            monthNames.Add(1, "January");
            monthNames.Add(2,  "February");
            monthNames.Add(3,  "March");
            monthNames.Add(4, "April");
            monthNames.Add(5, "May");
            monthNames.Add(6, "June");
            monthNames.Add(7, "July");
            monthNames.Add(8, "August");
            monthNames.Add(9, "September");
            monthNames.Add(10, "October");
            monthNames.Add(11, "November");
            monthNames.Add(12, "December");

            List<MonthWise> monthWises = new List<MonthWise>();

            IQueryable<ConsultantProject> projects = _context.ConsultantProjects.Where(a=>a.EntryDate.Value.Year == YearID);

            //adding the conditions...
            if (ProjectId > 0)
            {
              projects =  projects.Where(a=>a.ProjectID  == ProjectId);

            }
            if (MonthID > 0)
            {
                projects = projects.Where(a => a.EntryDate.Value.Month == MonthID);
            }
            if (UserID != null)
            {
                if (UserID != "")
                {
                    projects = projects.Where(a => a.UserID == UserID);
                }

            }

            var query = from a in projects
                        join User in _context.Users
                        on a.UserID equals User.Id
                        orderby a.Project.ProjectName,a.User.ConsultantName
                        select

                new
                {
                    ProjectID = a.Project.ProjectID,
                    ProjectName = a.Project.ProjectName,
                    UserID = a.UserID,
                    UserName = a.User.ConsultantName,
                    EntryDate = a.EntryDate,
                    TotalHours = (a.StartLunchTime == null && a.EndLunchTime == null)? EF.Functions.DateDiffMinute(a.StartTime, a.EndTime)/60: (EF.Functions.DateDiffMinute(a.StartTime, a.EndTime) - EF.Functions.DateDiffMinute(a.StartLunchTime, a.EndLunchTime)) / 60,
                    TotalMin = (a.StartLunchTime == null && a.EndLunchTime == null) ? EF.Functions.DateDiffMinute(a.StartTime, a.EndTime) % 60 : (EF.Functions.DateDiffMinute(a.StartTime, a.EndTime) - EF.Functions.DateDiffMinute(a.StartLunchTime, a.EndLunchTime)) % 60
                };

            if(query.Count() > 0)
            {
                var subquery = query.GroupBy(a => new
                {
                    a.ProjectID,
                    a.UserID,
                    a.EntryDate.Value.Month,

                }).OrderBy(a => a.Max(x => x.ProjectName)).ThenBy(a => a.Max(x => x.UserName)).ThenBy(a => a.Max(x => x.EntryDate.Value.Month)).
            Select(a => new { ProjectName = a.Max(x => x.ProjectName), UserName = a.Max(x => x.UserName), UserID = a.Max(x => x.UserID), MonthEntry = a.Max(x => x.EntryDate.Value.Month), HoursPerDay = a.Sum(x => x.TotalHours), MinPerDay = a.Sum(x => x.TotalMin) });


                if (subquery != null)
                {
                    foreach (var group in subquery)
                    {
                        int ? inta = 0;
                        int? intb = 0;
                        MonthWise monthwise = new MonthWise();
                        monthwise.ProjectName = group.ProjectName;
                        monthwise.Month = group.MonthEntry;
                        monthwise.MonthName = monthNames[monthwise.Month];
                        monthwise.UserID = group.UserID;
                        monthwise.ConsultantName = group.UserName;
                        if (group.MinPerDay > 60)
                        {
                           inta = group.MinPerDay / 60;
                           intb = group.MinPerDay % 60;

                        }
                        if ((intb > 0 && inta > 0) || ( inta > 0))
                            monthwise.NoOfHours = String.Format("{0,3:D2}", group.HoursPerDay + inta) + ":" + string.Format("{0,3:D2}", intb);

                        else
                            monthwise.NoOfHours = String.Format("{0,3:D2}", group.HoursPerDay ) + ":" + string.Format("{0,3:D2}", group.MinPerDay);

                      
                        monthWises.Add(monthwise);

                    }
                }

            }


            return monthWises;
        }

        public List<ConsultantProject> GetDateWiseDetails(string? UserId, int? MonthID,int? YearID, DateTime? DateOfSchedule)
        {
            List<ConsultantProject>  dateWises = new List<ConsultantProject>();
            var query = _context.ConsultantProjects.Include("Project").Where(a => a.UserID == UserId && a.EntryDate.Value.Year == YearID);
            if (query != null)
            {
                if(MonthID > 0)
                {
                    query = query.Where(a => a.EntryDate.Value.Month == MonthID);

                }
                if(DateOfSchedule !=null)
                {
                    query = query.Where(a=>a.EntryDate.Equals(DateOfSchedule));
                }

                                
                dateWises = query.OrderBy(a => a.ProjectID).ThenBy(a=>a.EntryDate).ToList();
            }

            return dateWises;

        }


        public string GetConsultantNameByID(string ID)
        {

            var name = _context.Users.Where(i => i.Id == ID).SingleOrDefault();
            string fullName;

            fullName = string.Concat(new string[] { name.ConsultantName });
            
           
            return fullName ;

        }
    }
}
//the application dbcontext has to derive from base identitydbcontext<Timeprojectuser>
//<a  class="nav-link text-dark" asp-area="Identity" asp-page="/Account/Manage/Index" title="Manage">Hello @User.Identity?.Name!</a>
/*  //This will raise an error
            //as cannot convert from Iqueryable <ananymous type> to Iqueryable<Student>
            // IQueryable<Student> Students2 = Students.Where(a => a.Name == "Akshita").Select(a => new { a.Name, a.Id }).AsQueryable();
            //This will work.. 
            IQueryable<Student> Students2 = Students.Where(a => a.Name == "Akshita").AsQueryable();
 */