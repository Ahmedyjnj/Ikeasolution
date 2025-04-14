using IKEa.DAL.Models.Departments;
using IKEa.DAL.Persinstance.Repositories._Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEa.DAL.Persinstance.Repositories.Departments
{
    class OracleDepartmentRepository : IDepartmentRepository
    {
        public void Add(Department entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Department entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Department> GetAll(bool withnotracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<Department>? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void update(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
