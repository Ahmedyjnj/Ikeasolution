using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea.BLL.Dto_s.Departments
{
    public class UpdatedDepartmentDto
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Name is required")]


        public string name { get; set; } = null!;

        [Required(ErrorMessage = "Code is required")]
        public string code { get; set; } = null!;

        [Display(Name = "Date of creation")]
        public DateOnly creationdate { get; set; }

 
        public string? description { get; set; }
    }
}
