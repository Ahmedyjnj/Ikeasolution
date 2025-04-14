using IKEa.DAL.Models;
using IKEa.DAL.Models.Employees;
using IKEa.DAL.Persinstance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEa.DAL.Persinstance.Repositories._Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        //public IEnumerable<T> GetAll(bool withnotracking = true)
        //{//Ienumerable is the interface that will be store in memory
         //in memory collection  and it is part of system.collections.generic 
         //Execute the query and store the result in memory as c#
         //load then filter in memory


            // Iqurable is the interface that will be come only from database
            //this is part of system.linq that work in sql in database
            //Execute the query and store the result in database as sql
            //filter in db then return





        //    if (withnotracking)
        //        return Context.Set<T>().Where(D => D.IsDeleted == false).AsNoTracking().ToList();

        //    return Context.Set<T>().Where(D => D.IsDeleted == false).ToList();
        //}




        private readonly ApplicationDbContext Context;

        public GenericRepository(ApplicationDbContext _context)
        {
            Context = _context;
        } //ask clr to generate options for my context



        public IQueryable<T> GetAll(bool withnotracking = true)
        {
            if (withnotracking)
                return Context.Set<T>().AsNoTracking();

            return Context.Set<T>();
        }




        public async Task<T>? GetById(int id) //this work as lazy we will fix it in api
        {
            var item =await Context.Set<T>().FindAsync(id); //asyncronus that mean that it not series that make it enable to be use parallel with others
            //await is used to make sure that the code will not be executed until the task is completed and free threads for other cods
            return item;
        }


        public void Add(T item)
        {
            Context.Set<T>().Add(item);
           
        }

        public void Delete(T item)
        {
            item.IsDeleted = true;
            Context.Set<T>().Update(item);
           
        }

      

        public void update(T item)
        {
            Context.Set<T>().Update(item);

           
        }
    }
}
