using Microsoft.AspNetCore.Mvc.Rendering;

namespace TimeReportProject.Repository
{
    public interface IUsers
    {
        public List<SelectListItem> GetUsersForDropDown();

    }

  }
