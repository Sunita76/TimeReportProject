using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TimeReportProject.Models;

namespace TimeReportProject.Areas.Identity.Data;

// Add profile data for application users by adding properties to the TimeReportProjectUser class
public class TimeReportProjectUser : IdentityUser
{
   
    public string? ConsultantName { get; set; }
    public ICollection<ConsultantProject > ConsultantProjects { get; set; } //Navigation property 
}

// Both the Tables Project and TimeProjectUser will have a navigation property of the JoinTable 
//ConsultantProject, Then in the fluent API define the key for the ConsultantProject table.
//In the Join table have the Project and TimeProjectUser property.
