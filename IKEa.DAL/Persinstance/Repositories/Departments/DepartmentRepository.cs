using IKEa.DAL.Models.Departments;
using IKEa.DAL.Persinstance.Data;
using IKEa.DAL.Persinstance.Repositories._Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEa.DAL.Persinstance.Repositories.Departments
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        //first thing in this sad class to make constructor and make a di
        //this service


        //the constructor is the reason of error because he inheritance from things that has a constructor 

        private readonly ApplicationDbContext Context;
        public DepartmentRepository(ApplicationDbContext _context): base(_context)
        {
            Context = _context;
        }

    }
}
