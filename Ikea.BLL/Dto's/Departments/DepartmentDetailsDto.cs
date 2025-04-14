using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea.BLL.Dto_s.Departments
{
    public class DepartmentDetailsDto
    {
        public int id { get; set; }
        public string name { get; set; } = null!;

        public string code { get; set; } = null!;

        public DateOnly creationdate { get; set; }

        public string? description { get; set; }


        #region Administrator
        public bool isdeleted { get; set; } //this is soft delete
        public int createdby { get; set; }

        public DateTime createdon { get; set; }

        public DateTime lastmodifiedon { get; set; }

        public int lastmodifiedby { get; set; }

        #endregion


    }
}
