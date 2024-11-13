using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Security.Claims;


using TimeReportProject.Models;
using TimeReportProject.Repository;
using TimeReportProject.ViewModels;

namespace TimeReportProject.Controllers
{
    public class TimeEntryController : Controller
    {
        private IProjects _project;
        private IConsultantSchedule _consultantSchedule;
        private IUsers _users;
        public TimeEntryController(IProjects project, IConsultantSchedule consultantschedule,IUsers users)
        {
            _project = project;
            _consultantSchedule = consultantschedule;
            _users = users;

        }
      
        [HttpGet]
        public IActionResult EnterTimeDetails()
        {
            ConsultantProjectViewModel model = new ConsultantProjectViewModel();

            model.ID = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //Find the Name of the consultant.
            model.ConsultantName = _consultantSchedule.GetConsultantNameByID(model.ID);
            model.ProjectList = _project.GetProjectForList();
            return View(model);

        }
        [HttpPost]
        public IActionResult EnterTimeDetails(ConsultantProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                ConsultantProject consultantProject = new ConsultantProject();

                consultantProject.UserID = model.ID;
                consultantProject.ProjectID = model.ProjectID;
                consultantProject.EntryDate = model.EntryDate;

               
                consultantProject.StartTime = model.StartTime;
                consultantProject.EndTime = model.EndTime;
               
                consultantProject.StartLunchTime = model.StartLunchTime;
               
                consultantProject.EndLunchTime = model.EndLunchTime;
                consultantProject.Comments = model.Comments;
                var result = _consultantSchedule.AddScheduleDetails(consultantProject);
                if (result == true)
                    ViewBag.Message = "The schedule details have been updated";
                else
                {
                    ViewBag.Message = "Error occured while adding the time details.";
                    //ViewBag.Message = _consultantSchedule.ErrorMessage;
                    //return View("Error");
                }
            }
            model.ProjectList = _project.GetProjectForList();
            return View(model);

        }

        [HttpGet]
        public IActionResult MonthWiseDetails(int? pageNo)
        {
            MonthWiseViewModel monthwisedetails = new MonthWiseViewModel();
            monthwisedetails.Projects = _project.GetProjectForList();
            monthwisedetails.Users = _users.GetUsersForDropDown();
            monthwisedetails.Months = FillMonthData();
            monthwisedetails.Years = FillYearData();

          
            return View(monthwisedetails);

        }
        public List<SelectListItem > FillYearData()
        {
            List<SelectListItem> yearList = new List<SelectListItem>();
            Dictionary<int, int> Years = new Dictionary<int, int>();
            for(int i= 2040; i>=2000;i--)
                Years.Add(i,i);
            yearList.AddRange(Years.Select(keyValuePair => new SelectListItem()
            {
                Value = keyValuePair.Value.ToString(),
                Text = keyValuePair.Key.ToString()
            }));

            SelectListItem item2 = new SelectListItem();
            item2.Text = "Select the Year";
            item2.Value = "";
            item2.Selected = true;
            yearList .Insert(0, item2);


            return yearList;    
        }
        public List<SelectListItem > FillMonthData()
        {
            //Months List
            Dictionary<string, int> monthNames = new Dictionary<string, int>();
            monthNames.Add("January", 1);
            monthNames.Add("February", 2);
            monthNames.Add("March", 3);
            monthNames.Add("April", 4);
            monthNames.Add("May", 5);
            monthNames.Add("June", 6);
            monthNames.Add("July", 7);
            monthNames.Add("August", 8);
            monthNames.Add("September", 9);
            monthNames.Add("October", 10);
            monthNames.Add("November", 11);
            monthNames.Add("December", 12);
            List<SelectListItem> Mnames = new List<SelectListItem>();

            Mnames.AddRange(monthNames.Select(keyValuePair => new SelectListItem()
            {
                Value = keyValuePair.Value.ToString(),
                Text = keyValuePair.Key
            }));
            

            SelectListItem item2 = new SelectListItem();
            item2.Text = "Select the Month";
            item2.Value = "";
            item2.Selected = true;
            Mnames.Insert(0, item2);
            return Mnames;
        }
      


        [HttpPost]
        public IActionResult MonthWiseDetailsSearch(int? ProjectId,int? MonthID,int? YearID,string? userId, int? pageNo)
        {
            MonthWiseViewModel monthwisedetails = new MonthWiseViewModel();
            monthwisedetails.MonthWise = _consultantSchedule.GetMonthWiseDetails(ProjectId , MonthID,YearID, userId);

            //include the logic for pagination
            int pageSize = 10;
            int PNo;
            PNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            int skip = (PNo - 1) * pageSize;
            var totalRecords = monthwisedetails.MonthWise.Count();
            monthwisedetails.MonthWise = monthwisedetails.MonthWise.Skip(skip).Take(pageSize).ToList();
            monthwisedetails.Pager = new Pager(totalRecords, PNo, pageSize);
            monthwisedetails.Projects = _project.GetProjectForList();
            monthwisedetails.Users = _users.GetUsersForDropDown();
            monthwisedetails.Months = FillMonthData();
            monthwisedetails.Years = FillYearData();
            monthwisedetails.MonthID = MonthID;
            monthwisedetails.YearID = YearID;
            monthwisedetails.UserID = userId;
            monthwisedetails.ProjectID = ProjectId;

            return View("MonthWiseDetails", monthwisedetails);

        }
        public IActionResult DateWiseDetails()
        {
            DayWiseViewModel model = new DayWiseViewModel();
            model.Months = FillMonthData();
            model.Users = _users.GetUsersForDropDown();
           
            return View(model);

        }

        [HttpPost]
        public IActionResult DateWiseDetails( string? UserId,int? MonthID,DateTime? ScheduleDate,int? pageNo)
        {
            DayWiseViewModel model = new DayWiseViewModel();
            
            //include the logic for pagination
            int pageSize = 10;
            int PNo;
            int YearID;
            YearID = DateTime.Now.Year; // the report is for the current financial year.

            PNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            int skip = (PNo - 1) * pageSize;
            model.DayWiseDetails = _consultantSchedule.GetDateWiseDetails(UserId, MonthID,YearID, ScheduleDate);
            var totalRecords = model.DayWiseDetails .Count();
            model.DayWiseDetails  = model.DayWiseDetails.Skip(skip).Take(pageSize).ToList();
            model.Months = FillMonthData();
            model.Users = _users.GetUsersForDropDown();
            model.Pager = new Pager(totalRecords, PNo, pageSize);
            return View(model);

        }

    }
}
//string STime, ETime, SLTime, ELTime;
//STime = Convert.ToDateTime(model.StartTime).ToString("HH:mm");
//ETime = Convert.ToDateTime(model.EndTime).ToString("HH:mm");
//SLTime = Convert.ToDateTime(model.StartLunchTime).ToString("HH:mm");
//ELTime = Convert.ToDateTime(model.EndLunchTime).ToString("HH:mm");
// STime = String.Format(Convert.ToDateTime(model.StartTime).Hour.ToString(),"00") + ":" + String.Format(Convert.ToDateTime(model.StartTime).Minute.ToString(),"00");
//ETime = String.Format(Convert.ToDateTime(model.EndTime).Hour.ToString(),"00") + ":" + String.Format(Convert.ToDateTime(model.EndTime).Minute.ToString(),"00");



//@if(Model.ShowRequestId)
//{
//    < p >
//        < strong > Request ID:</ strong > < code > @Model.RequestId </ code >

//       </ p >
//}

// //data:$('#projectform').serialize() is used to pass the modal data to the controller, but as I had to pass the page no also, I
//could not see how to pass Modal data and the pageNo, so I used diff variables to be passing the val() of the dropdown list to the controller.
