using IKEa.DAL.Models;
using IKEa.DAL.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEa.DAL.Persinstance.Repositories._Generic
{
   public interface IGenericRepository<T> where T : ModelBase // where t inherit modelbase
    {

        //t should be part of family of interface modelbase
        // we make this because implementation of a department and employee is same



        IQueryable<T> GetAll(bool withnotracking = true);

        Task<T>? GetById(int id);

        void Add(T entity);

        void update(T entity);

        void Delete(T entity);






    }
}
