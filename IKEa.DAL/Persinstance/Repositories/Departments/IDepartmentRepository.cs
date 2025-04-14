using IKEa.DAL.Models.Departments;
using IKEa.DAL.Persinstance.Repositories._Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEa.DAL.Persinstance.Repositories.Departments
{
    //as services and crud operations of repository
    //we need to make a - GetAll - GetByID -Update - Delete -
    public interface IDepartmentRepository :IGenericRepository<Department>
    {
     


    }
}
