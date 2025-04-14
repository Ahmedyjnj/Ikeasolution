using IKEa.DAL.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEa.DAL.Models.Departments
{
    public class Department : ModelBase
    {

        public string Name { get; set; } = null!; 
        //this warning because non nullable proberty
        //must contain null to fix that....

        public string Code { get; set; }=null!;

        public string? Description { get; set; } 


        public DateOnly CreationDate { get; set; }
        //دى خاصية بالاصدار النهائى التانية خاصية بالسيستم

        //now we will make alot of employees in this dep


        //navigational proberty many in department
        public virtual ICollection<Employee> Employees { get; set; }  =new HashSet<Employee>();

    }
}
