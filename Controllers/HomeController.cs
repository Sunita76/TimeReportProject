using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using TimeReportProject.Models;
using TimeReportProject.Repository;
using TimeReportProject.ViewModels;

namespace TimeReportProject.Controllers
{
    public class HomeController : Controller
    {
        private IProjects _project;
        public HomeController(ILogger<HomeController> logger,IProjects project)
        {
            _project = project;
            _logger = logger;
        }
        public IActionResult GetProjectDetails()
        {
            ProjectViewModel projectViewModel = new ProjectViewModel();
            projectViewModel.Projects = _project.GetAllProjects();
            return View(projectViewModel);

        }

        [HttpGet]
        public IActionResult AddProjectDetails()
        {
            ProjectViewModel model = new ProjectViewModel();
            return PartialView("_action", model); //fills up the modal inside the partial view in the 
            //success of the $.ajax..


        }
        //the same post action method for add and edit
        [HttpPost]
        public ActionResult ProjectDetails(ProjectViewModel model)
        {
           
            Project project = new Project();
            var result= false ;
           if (model.ProjectID > 0)
            {
                project = _project.GetProjectByID(model.ProjectID );
                project.ProjectName = model.ProjectName;
                project.ProjectDesc = model.ProjectDesc;
                result  = _project.UpdateProjectDetails(project);
            }
            else
            {
                project.ProjectName = model.ProjectName;
                project.ProjectDesc = model.ProjectDesc;
                result  = _project.AddProjectDetails(project);
            }
            
            if (result == true)
                return RedirectToAction("GetProjectDetails");
            else
            {
                ViewBag.Message = "Error occured while adding the project details.";
                return View("Error");

            }

        }
        [HttpGet]
        public ActionResult EditProjectDetails(int ID)
        {
            ProjectViewModel model = new ProjectViewModel();
            model.ProjectID = ID;
            Project project = new Project();
            project = _project.GetProjectByID(ID);
            model.ProjectName = project.ProjectName;
            model.ProjectDesc = project.ProjectDesc;
            model.Projects = _project.GetAllProjects();
            return PartialView ("_action",model);

        }

        private readonly ILogger<HomeController> _logger;


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
//to get the identity related classes, use the additem->scafollding item >identiy.
//The register.cs will be the code file inside Register.cshtml.
//changing the User name in Identity is giving a problem in Login process.
//I tried to change the UserName from Input.Email to ConsultantName.
// I commented the code for Email verification for the register purpose. Then in the program.cs , the signin options also
// requireverifiedaccount and requirevrefiedemail is set to false.



      