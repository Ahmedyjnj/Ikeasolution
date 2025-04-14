using IKEa.DAL.Persinstance.Data;
using IKEa.DAL.Persinstance.Repositories.Departments;
using IKEa.DAL.Persinstance.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEa.DAL.Persinstance.UnitOfWork
{
   public class UnitOfWork : IUnitOfWork

    {
        private readonly ApplicationDbContext dbContext;

        public IDepartmentRepository DepartmentRepository { get ; set; }
        public IEmployeeRepository EmployeeRepository { get ; set; }
        

        public UnitOfWork(ApplicationDbContext dbContext) //we will ask clr to generate object from 
        {
            this.dbContext = dbContext;

            DepartmentRepository = new DepartmentRepository(dbContext);

            EmployeeRepository = new EmplyeeRepository(dbContext);


        }
        public async Task<int> complete()
        {
            return await dbContext.SaveChangesAsync();

        }

        //public void Dispose() //we will use it when we make a object not with clr will close to close it
        //{//in interface we will inherit from interface IDisposable to make it close automatic
        //    dbContext.Dispose();
        //}
    }
}
