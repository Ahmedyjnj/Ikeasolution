using IKEa.DAL.Common.Enums;
using IKEa.DAL.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEa.DAL.Persinstance.Data.Configurations.EmployeeConfigurations
{
    class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("varchar(50)").IsRequired();

            builder.Property(E => E.Address).HasColumnType("varchar(100)");


            builder.Property(E => E.Salary).HasColumnType("decimal(8,2)");

            //we need him to store a vlue of string enum in database rather than int 


            builder.Property(E => E.Gender).HasConversion(


                (gender) => gender.ToString(), // in store he will convert it to string 

                (genderstr) => (Gender)Enum.Parse(typeof(Gender), genderstr) // in retrive he will convert it to enum 

                );

            builder.Property(E => E.EmployeeType).HasConversion(


                (type) => type.ToString(), // in store he will convert it to string 
                (typestr) => (EmployeeType)Enum.Parse(typeof(EmployeeType), typestr) // in retrive he will convert it to enum

                );



            builder.Property(D => D.CreatedOn).HasDefaultValueSql("getdate()");

            builder.Property(D => D.LastModifiedOn).HasDefaultValueSql("getdate()");









        }
    }
}
