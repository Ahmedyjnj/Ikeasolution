using IKEa.DAL.Common.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea.BLL.Dto_s.Employees
{
    public class CreatedEmployeeDto
    {


        [MaxLength(50,ErrorMessage ="max length of name is 50 char")]
        [MinLength(5,ErrorMessage ="min length of name is 5 char")]
        public string Name { get; set; }



        [Range(22,30)]

        public int? Age { get; set; }

        [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$",
            ErrorMessage = "address must be like 123-street-city-country")]
        public String? Address { get; set; }


        public decimal Salary { get; set; }

        [Display(Name="Is Active")]
        public bool IsActive { get; set; } //he work or has left the company

        [EmailAddress]
        public string? Email { get; set; }

        [Display(Name="phone number")]
        [Phone]
        public string? PhoneNumber { get; set; }


        public DateOnly HiringDate { get; set; }


        public Gender Gender { get; set; }


        public EmployeeType EmployeeType { get; set; }

        [Display(Name ="Department~")]
        
        public int? DepartmentId { get; set; }


        public IFormFile? Image { get; set; }  //we should make it nullable


    }
}
