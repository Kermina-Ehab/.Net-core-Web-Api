using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiCore.Models
{
    public class Model:DbContext
    {
        public Model(DbContextOptions<Model> options):base(options)
        {

        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }

    }
}
