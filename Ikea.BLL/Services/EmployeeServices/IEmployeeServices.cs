using Ikea.BLL.Dto_s.Departments;
using Ikea.BLL.Dto_s.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea.BLL.Services.EmployeeServices
{
   public  interface IEmployeeServices
    {




        Task<IEnumerable<EmployeeDto>> GetAllEmployees(string search); //in this to list async


        Task<EmployeeDetailsDto>? GetEmployeeById(int id); // in this get by id async in find

        Task<int> CreateEmployee(CreatedEmployeeDto employeeDto);


        Task<int> UpdateEmployee(UpdatedEmployeeDto employeeDto);

        Task<bool> DeleteEmployee(int id);

        // we will make it to work with more requests and because a save in all of it is async
        //because complete function of save 







    }
}
