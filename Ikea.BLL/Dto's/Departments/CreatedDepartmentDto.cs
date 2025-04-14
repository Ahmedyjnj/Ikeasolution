using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea.BLL.Dto_s.Departments
{
    public class CreatedDepartmentDto
    {
        [Required(ErrorMessage ="name is required  ")]
        public string name { get; set; } = null!;

        [Required(ErrorMessage = "Code is required my code ")] //this is server side validation as notation
        public string code { get; set; } = null!;

        public string? description { get; set; }

        [Display(Name="date of creation")]
        public DateOnly creationdate { get; set; }


    }
}
