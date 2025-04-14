using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea.BLL.Dto_s.Departments
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
       
        public string Code { get; set; } = null!;

        [Display(Name="Date Of Creation")]
        public DateOnly CreationDate { get; set; }

        //public string? Description { get; set; }



        //public bool IsDeleted { get; set; } //this is soft delete
        //public int CreatedBy { get; set; }

        //public DateTime CreatedOn { get; set; }

        //public int LastModifiedOn { get; set; }


    }
}
