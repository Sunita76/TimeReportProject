using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeReportProject.Areas.Identity.Data;
using TimeReportProject.Models;

namespace TimeReportProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<TimeReportProjectUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Project> Projects { get; set; }
        public DbSet<ConsultantProject> ConsultantProjects { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            // builder.Entity<ConsultantProject>().HasKey(sc => new { sc.ID, sc.ProjectID });
            builder.Entity<ConsultantProject >().HasKey(i => new { i.UserID, i.ProjectID ,i.EntryDate  });
        }
    }
}
//Entity framework tools is needed for Add-Migration and Update-database commands.
//Entity framework Sqlserver is needed for DBContext in core.