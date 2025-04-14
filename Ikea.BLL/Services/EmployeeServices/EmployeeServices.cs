using Ikea.BLL.Common.Services.Attachments;
using Ikea.BLL.Dto_s.Departments;
using Ikea.BLL.Dto_s.Employees;
using IKEa.DAL.Models.Employees;
using IKEa.DAL.Persinstance.Repositories.Employees;
using IKEa.DAL.Persinstance.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea.BLL.Services.EmployeeServices
{
   public  class EmployeeServices: IEmployeeServices
    {
        //private readonly IEmployeeRepository Repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IAttachmentServices attachmentServices;

        public EmployeeServices( IUnitOfWork unitOfWork,IAttachmentServices attachmentServices )            //IEmployeeRepository employeeRepository)
        {
            //Repository = employeeRepository;
            this.unitOfWork = unitOfWork;
            this.attachmentServices = attachmentServices;
        }


        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees(string search)  //we wikll make a iqurable as a repository and it will be a empty until it has dat a
        {
            var Employees = unitOfWork.EmployeeRepository.GetAll();

            var filteredEmployees = Employees.Where(E=>E.IsDeleted == false && (string.IsNullOrEmpty(search) || E.Name.ToLower().Contains(search.ToLower()))).Include(E=>E.Department);
            //that include will work as a eager loading  in pull the one department to aevery employee that  better than 
            //making a it as default lazy because problem N+1
            
            var AfterFileration=filteredEmployees.Select(E => new EmployeeDto()
            {
                Id = E.Id,
                Name = E.Name,
                Age = E.Age,
                Email = E.Email,
                IsActive = E.IsActive,
                Salary = E.Salary,
                Gender = E.Gender,
                EmployeeType = E.EmployeeType,
                Department = E.Department != null ? E.Department.Name : "N/A"
            }); //we will see how he will load a department in employee index
            //by eager or lazy loading

            return await AfterFileration.ToListAsync();

            //he will return only when we make a tolist as it as select
            //we use iqurable in sql  repo and
            //in service ienumerable

           







            //return Repository.GetAll().Where(E => E.IsDeleted == false).Select(E => new EmployeeDto()
            //{
            //    Id = E.Id,
            //    Name = E.Name,
            //    Age = E.Age,
            //    Email = E.Email,
            //    IsActive = E.IsActive,
            //    Salary = E.Salary,
            //    Gender = E.Gender,
            //    EmployeeType =E.EmployeeType
            //}).ToList();
        }

        public async Task<EmployeeDetailsDto>? GetEmployeeById(int id)
        {
            var employee = await unitOfWork.EmployeeRepository.GetById(id);

            if (employee is not null)
            {
                return new EmployeeDetailsDto()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Age = employee.Age,
                    Email = employee.Email,
                    IsActive = employee.IsActive,
                    Salary = employee.Salary,
                    Address = employee.Address,
                    PhoneNumber = employee.PhoneNumber,
                    HiringDate = employee.HiringDate,
                    Gender = employee.Gender,
                    EmployeeType = employee.EmployeeType,
                    CreatedBy = employee.CreatedBy,
                    CreatedOn = employee.CreatedOn,
                    LastModifiedBy = employee.LastModifiedBy,
                    LastModifiedOn = employee.LastModifiedOn,
                    Department=employee.Department?.Name,
                    ImageName = employee.ImageName,
                    DepartmentId = employee.DepartmentId


                };
            }
            return null;

            //to make auto mapper should download it for pl 
            //bll and dal factors 




        }

        public async Task<int> CreateEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee = new Employee() //Image Name => string =>upload
            {
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                Salary = employeeDto.Salary,
                IsActive = employeeDto.IsActive,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                HiringDate = employeeDto.HiringDate,
                Gender = employeeDto.Gender,
                EmployeeType = employeeDto.EmployeeType,
                DepartmentId = employeeDto.DepartmentId,    
               
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now
               

            };

            if (employeeDto.Image is not null)
            {
               employee.ImageName= attachmentServices.UploadImage(employeeDto.Image,"images");

            }



            unitOfWork.EmployeeRepository.Add(employee);

            return await unitOfWork.complete();

        }

        public async  Task<bool> DeleteEmployee(int id)
        {
            var employee = await unitOfWork.EmployeeRepository.GetById(id);

            if (employee is not null)
            {
                if (employee.ImageName is not null)
                {
                    var filepath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","Files","images",employee.ImageName );

                    attachmentServices.DeleteImage(filepath);


                }


                unitOfWork.EmployeeRepository.Delete(employee);

            }

             var Result= await unitOfWork.complete() ;

            if (Result>0)
            {
                return true;
            }
            else
                return false;
        }

      

        public async Task<int> UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            var emplyee = new Employee()
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                Salary = employeeDto.Salary,
                IsActive = employeeDto.IsActive,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                HiringDate = employeeDto.HiringDate,
                Gender = employeeDto.Gender,
                EmployeeType = employeeDto.EmployeeType,

                DepartmentId=employeeDto.DepartmentId,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,
                ImageName = employeeDto.ImageName

            };

            if (employeeDto.Image is not null)
            {

                if (emplyee.ImageName is not null)

                {
                    var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "images", emplyee.ImageName);

                    attachmentServices.DeleteImage(filepath);
                }
                emplyee.ImageName = attachmentServices.UploadImage(employeeDto.Image, "images");
            }
           

            unitOfWork.EmployeeRepository.update(emplyee);
            return await unitOfWork.complete();
        }
    }
}
