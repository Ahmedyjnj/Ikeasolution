using Ikea.BLL.Dto_s.Departments;
using IKEa.DAL.Models.Departments;
using IKEa.DAL.Persinstance.Repositories.Departments;
using IKEa.DAL.Persinstance.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea.BLL.Services.DepartmentServices
{
    public class DepartmentService:IDepartmentService
    {//controller=> service => repository => context => options
        private readonly IUnitOfWork unitOfWork;

        //this use repository


        //private IDepartmentRepository Repository;
        public DepartmentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            //Repository = _Repository;
        }
        //implementation of services
        // we now in bll we use a repository to call DAL so we will inject it in services

        //there are package in bll to automapper we will use it in complex
        public async Task<IEnumerable<DepartmentDto>> GetAllDepartments()
        {
            //an new way
            var Departments = await unitOfWork.DepartmentRepository.GetAll().Select(dept => new DepartmentDto()
            {
                Id = dept.Id,
                Name = dept.Name,
                Code = dept.Code,
                CreationDate = dept.CreationDate
            }).ToListAsync();
            return Departments;
            //an old way

            //now make convert from department to dto

            //var Departments = Repository.GetAll();
            //List<DepartmentDto> departmentDtos = new List<DepartmentDto>();

            //foreach (var dept in Departments)
            //{
            //    DepartmentDto departmentDto = new DepartmentDto()
            //    {
            //        Id=dept.Id,
            //        Name=dept.Name,
            //        Code=dept.Code,
            //        CreationDate=dept.CreationDate //this is auto mapper
            //    };
            //    departmentDtos.Add(departmentDto);
            //}
            //return departmentDtos;
        }

        public async Task<DepartmentDetailsDto>? GetDepartmentById(int id)
        {
            var department =await unitOfWork.DepartmentRepository.GetById(id);

            if (department is not null)
                return new DepartmentDetailsDto()
                {
                    id=department.Id,
                    name=department.Name,
                    code=department.Code,
                    creationdate=department.CreationDate,
                    isdeleted=department.IsDeleted,
                    lastmodifiedon=department.LastModifiedOn,
                    createdby=department.CreatedBy,
                    createdon=department.CreatedOn,
                    lastmodifiedby=department.LastModifiedBy,
                    description=department.Description
                };

            return null;
        }


        public async Task<int> CreateDepartment(CreatedDepartmentDto departmentDto)
        {
            var CreateDepartment = new Department()
            {
                Code = departmentDto.code,
                Name = departmentDto.name,
                Description = departmentDto.description,
                CreationDate = departmentDto.creationdate,
                CreatedBy = 1,
                LastModifiedOn = DateTime.Now,
                LastModifiedBy=1,
                CreatedOn=DateTime.Now,
            };
             unitOfWork.DepartmentRepository.Add(CreateDepartment);
            return await unitOfWork.complete();
        }


        public async Task<int> UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            var UpdatedDepartment = new Department()
            {
                Id=departmentDto.id,
                Code=departmentDto.code,
                Name=departmentDto.name,
                Description=departmentDto.description,
                CreationDate=departmentDto.creationdate,
                LastModifiedBy=1,
                LastModifiedOn=DateTime.Now
            };
             unitOfWork.DepartmentRepository.update(UpdatedDepartment);
            return await unitOfWork.complete();
        }

        public async  Task<bool> DeleteDepartment(int id)
        {

            var department = await unitOfWork.DepartmentRepository.GetById(id);

            if (department is not null)
                unitOfWork.DepartmentRepository.Delete(department);

            var Result = await unitOfWork.complete();

            if (Result > 0)
            {
                return true;
            }
            else
                return false;
            //var department = Repository.GetById(id);

            ////a new way

            //if (department is not null)
            //    return Repository.Delete(department) > 0;
            //else
            //    return false;

            //int result=0;
            //if (department is not null)
            //    result= Repository.Delete(department);

            //if (result > 0)
            //    return true;

            //else
            //    return false;
        }








    }
}
