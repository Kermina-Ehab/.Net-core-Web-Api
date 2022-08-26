using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCore.Models
{
    public class Department
    {

        public int id { get; set; }
        [Required]
        public string name { get; set; }

        public virtual List<Employee> emps { get; set; } = new List<Employee>();
    }
}
