﻿using IKEa.DAL.Common.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea.BLL.Dto_s.Employees
{
    public class UpdatedEmployeeDto
    {
        public int Id { get; set; }


        public string Name { get; set; }

        public int? Age { get; set; }


        public String? Address { get; set; }


        public decimal Salary { get; set; }

        public bool IsActive { get; set; } //he work or has left the company

        public string? Email { get; set; }


        public string? PhoneNumber { get; set; }


        public DateOnly HiringDate { get; set; }


        public Gender Gender { get; set; }


        public EmployeeType EmployeeType { get; set; }




        public int? DepartmentId { get; set; }

        public string? ImageName { get; set; } //For old image 

        public IFormFile? Image { get; set; } //for update image for new image





    }
}
