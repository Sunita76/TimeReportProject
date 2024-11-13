using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TimeReportProject.Areas.Identity.Data;
using TimeReportProject.Models;

namespace TimeReportProject.ViewModels
{
    public class MonthWiseViewModel
    {
        public List<MonthWise> MonthWise { get; set; }
        public int? ProjectID { get; set; }
        public List<SelectListItem> Projects { get; set; }
        public string? UserID { get; set; }
        public List<SelectListItem> Users { get; set; }

        public List<SelectListItem> Months { get; set; }
       
        public int? YearID { get;set; }
        public List<SelectListItem> Years { get; set; }
        public int? MonthID { get; set; }
        public Pager Pager{get;set;}

    }



    public class Pager
    {
        public Pager(int totalItems, int? page, int pageSize = 10)
        {
            if (pageSize == 0) pageSize = 10;

            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            var currentPage = page != null ? (int)page : 1;
            var startPage = currentPage - 5;
            var endPage = currentPage + 4;
            if (startPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }

        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
    }
}
