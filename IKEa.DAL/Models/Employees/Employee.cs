using IKEa.DAL.Common.Enums;
using IKEa.DAL.Models.Departments;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEa.DAL.Models.Employees
{
    public class Employee : ModelBase
    {
        public string Name { get; set; }=null!;

        public int? Age { get; set; }


        public String? Address { get; set; }


        public decimal Salary { get; set; }



        public bool IsActive { get; set; } //he work or has left the company

        public string? Email { get; set; }


        public string? PhoneNumber { get; set; }


        public DateOnly HiringDate { get; set; }

        //in options of gender and time of work we have two options 
        //male-female , parttime-fulltime
        //so we will use enum for make this types of work 
        //for this we will make folder common in Dal --- in it make folder Enums 


        public Gender Gender { get; set; }


        public EmployeeType EmployeeType { get; set; }


        //we in the last night fight to a work with relations between two tables

        //this navigational proberty as one dep to every employee

        //proberty for relation and  one for table
        //



        //
        public int? DepartmentId { get; set; }
 



        //navigational proberty one dep in this 
        public virtual Department? Department { get; set; }



        public  string? ImageName { get; set; }
        //this is the image of employee as name and we will assign it first thing to make by this two way after binary 
        //or by string and we will use it in the view to show the image of employee

        //now we will  know context and output automatic in add-migration 


        //the only place to put the image and data in wwwroot





    }
}
