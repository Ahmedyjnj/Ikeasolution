using IKEa.DAL.Persinstance.Repositories.Departments;
using IKEa.DAL.Persinstance.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEa.DAL.Persinstance.UnitOfWork
{
    public interface IUnitOfWork/*: IDisposable*/
    {
        public IDepartmentRepository DepartmentRepository { get;  }

        public IEmployeeRepository EmployeeRepository { get;  }


        public Task<int> complete();
        //void Dispose();
    }
}
