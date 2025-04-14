using Ikea.BLL.Dto_s.Departments;
using IKEa.DAL.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea.BLL.Services.DepartmentServices
{
    public interface IDepartmentService
    {
        //we will work services as concreate class from interface

        ////////////////////////////////settion 4 
        ///
        ///department services & dto's

        //in dtos we dont take type of department because we dont need every part of it in view

        //dto : data transfer object we dont need department to be out of his layer

        //in bbl make folder Dto's-- in it make --Departments --DepartmentDtos --DepartmentDetailsDto
        //copy data from modelbase and department to dto but delete what we not need 

        ////now we will use a dtos to implement a functions in services from repository
        ///

        Task<IEnumerable<DepartmentDto>> GetAllDepartments();


        Task<DepartmentDetailsDto>? GetDepartmentById(int id);

        Task<int> CreateDepartment(CreatedDepartmentDto departmentDto);


        Task<int> UpdateDepartment(UpdatedDepartmentDto departmentDto);

        Task<bool> DeleteDepartment(int id);

    }
}
