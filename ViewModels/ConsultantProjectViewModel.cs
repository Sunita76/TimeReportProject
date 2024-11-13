using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeReportProject.ViewModels
{
    public class ConsultantProjectViewModel
    {
        public string ID { get; set; }
        public string ConsultantName { get; set; }

        public List<SelectListItem>? ProjectList { get; set; }
      
        public string? ProjectName { get; set; }
        
        [Required (ErrorMessage ="Select the Project")]
        public int? ProjectID { get; set; }

        [Required (ErrorMessage ="Select the date for reporting the time schedule")]
        [DataType(DataType.Date)]
        // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime? EntryDate { get; set; }

        [Required (ErrorMessage ="From Time cannot be blank")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? StartTime { get; set; }

        [Required (ErrorMessage ="To Time cannot be blank")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? EndTime { get; set; }

        
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? StartLunchTime { get; set; }

       
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? EndLunchTime { get; set; }
       public string? Comments { get;set; }

 
    }
}
//if i dont make the property as nullable, then the validation error shows the value "is invalid error.