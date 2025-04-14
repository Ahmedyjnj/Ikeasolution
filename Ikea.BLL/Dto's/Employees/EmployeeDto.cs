using IKEa.DAL.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea.BLL.Dto_s.Employees
{
   public class EmployeeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Age { get; set; }



        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }


        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } //he work or has left the company

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }


        public Gender Gender { get; set; }   /*null!*/


        public EmployeeType EmployeeType { get; set; }

        public string? Department { get; set; }


    }
}
