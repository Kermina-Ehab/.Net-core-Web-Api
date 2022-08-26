using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace ApiCore.Models
{
    public class Employee
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int age { get; set; }

        [ForeignKey("dept")]
        public int  deptid { get; set; }
        public virtual Department dept { get; set; }
      

    }
}
