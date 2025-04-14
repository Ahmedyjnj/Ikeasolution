using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEa.DAL.Models
{
    public class ModelBase //to shared entites //make inheritance from it in
    {
        public int Id { get; set; }

        public bool IsDeleted { get;set; } //this is soft delete
        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get;set; }



    }
}
