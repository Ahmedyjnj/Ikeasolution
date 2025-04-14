using IKEa.DAL.Models.Departments;
using IKEa.DAL.Models.Employees;
using IKEa.DAL.Persinstance.Data;
using IKEa.DAL.Persinstance.Repositories._Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEa.DAL.Persinstance.Repositories.Employees
{
    public class EmplyeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext Context;
        public EmplyeeRepository(ApplicationDbContext _context) : base(_context)
        {
            Context = _context;
        }






        //employee services & Dto's














        //private readonly ApplicationDbContext Context;

        //public EmplyeeRepository(ApplicationDbContext context)
        //{
        //    Context = context; //this will make an object we need to make clr make it automatically
        //}


        public int Add(Employee employee)
        {
            Context.Employees.Add(employee);
            return Context.SaveChanges();
        }

        public int Delete(Employee employee)
        {
            employee.IsDeleted = true;
            Context.Employees.Update(employee);
            return Context.SaveChanges();
            //Context.Departments.Remove(department);
            //return Context.SaveChanges();
        }
        //soft delete like is deleted =true

        public IEnumerable<Employee> GetAll(bool withnotracking = true)
        {
            if (withnotracking)
                return Context.Employees.Where(D => D.IsDeleted == false).AsNoTracking().ToList();

            return Context.Employees.Where(D => D.IsDeleted == false).ToList();

            //no tracking(saving) if it only read with tracking if add or ......

        }

        public Employee? GetById(int id)
        {
            var employee = Context.Employees.Find(id);
            //var department = Context.Departments.Local.FirstOrDefault(D=>D.Id==id);

            //if (department is null)
            //    department = Context.Departments.FirstOrDefault(D => D.Id == id);
            return employee;

            //search local then in database

        }

        public int update(Employee employee)
        {
            Context.Employees.Update(employee);

            return Context.SaveChanges();
        }
    }
}
