using IKEa.DAL.Models.Departments;
using IKEa.DAL.Models.Employees;
using IKEa.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IKEa.DAL.Persinstance.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser> //IdentityUser IdentityRole  string
    {   //DI

        //Department => context => options




        //dependancy injection is that there are object has already create 
        //clr will give you it rather than make a new object 



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=Ikea_G02;Trusted_Connection=true;TrustCertificate=true");
        //} //we used it in old make connection like this not prefer


        
        //ask clr to generate options for my context
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }


        //this code that we write will search automatic on any class implement Ientitytypeconfiguration

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //he dont find a primary key because we work by this way in configuration that disaple his configuration

            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }//this code that we write will search automatic on any class implement Ientitytypeconfiguration


        //in old we had to write connection in on cofigure
        //now we will write in Data-Configuration -make folder Departmentconfiguration
        //- make class Departmentconfiguration

        public DbSet<Department> Departments { get; set; }


        public DbSet<Employee> Employees { get; set; }  



        //public DbSet<IdentityUser> Users { get; set; }



    }
}
