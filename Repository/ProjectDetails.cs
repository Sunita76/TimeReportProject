using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TimeReportProject.Data;
using TimeReportProject.Models;


namespace TimeReportProject.Repository
{

    public class ListUsers : IUsers
 
    {
        private ApplicationDbContext _context { get; set; }
        public ListUsers(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<SelectListItem> GetUsersForDropDown()
        {
            List<SelectListItem> users = new List<SelectListItem>();
            users = _context.Users.Where(a => a.UserName != "admin@easytotrust.com").ToList().ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.ConsultantName,
                    Value = a.Id,
                    Selected = false
                };
            });
            SelectListItem item1 = new SelectListItem();
            item1.Text = "Select the Consultant";
            item1.Value = "";
            item1.Selected = true;
            users.Insert(0, item1);
            return users;
        }
    }


    public class ProjectDetails :IProjects 
    {public string ErrorMessage { get; set; }
        private ApplicationDbContext  _context { get; set; }
       
        public ProjectDetails(ApplicationDbContext  context)
        {
            _context = context;
        }
        public List<Project> GetAllProjects()
        {
            List<Project> Projects = new List<Project>();
            try
            {

                Projects = _context.Projects.ToList();
                return (Projects);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.InnerException.Message;
                return(Projects);
            }
            
        }

        public List<SelectListItem> GetProjectForList()
        {
       List<SelectListItem > Projects = new List<SelectListItem>();
           Projects  = _context.Projects.ToList().ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.ProjectName,
                    Value = a.ProjectID.ToString(),
                    Selected = false
                };
            });
            SelectListItem item = new SelectListItem();
            item.Text = "Select the Project Name";
            item.Value = "";
            item.Selected = true;

            Projects .Insert(0, item);
            return (Projects);  
        }


       public  Project GetProjectByID(int? ID)
        {
            try
            {

                return _context.Projects.Where(a => a.ProjectID == ID).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool AddProjectDetails(Project project)
        {
            try
            {
                _context.Projects.Add(project);
                return _context.SaveChanges() > 0;

            }
            catch (DbUpdateException ex)
            {
                ErrorMessage = ex.InnerException.Message;
                return false;
            }

            catch (Exception ex)
            {
                ErrorMessage = "One or more errors occured while saving the record";
                return false;

            }


        }
        public bool UpdateProjectDetails(Project project )
        {
            _context.Entry(project).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

    }
}
