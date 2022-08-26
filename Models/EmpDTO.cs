using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCore.Models
{
    public class EmpDTO
    {
        
        [Required]
        public string name { get; init; }
        [Required]
        public int age { get; init; }
        
        public string deptname { get; init; }

    }
}
