using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiCore.Models
{

   public interface IitemsRepository
    {
        List<Employee> GetEmps();
        Employee GetEmp(int id);
        Employee Add(Employee emp1);
        Employee Update(int id);
        Employee Delete(int id);
    }
    public class ItemsReposatory:IitemsRepository
    {
        readonly Model md;
        public ItemsReposatory( Model md)
        {
            this.md = md;
        }
        
        public List<Employee> GetEmps()
        {
            return md.employees.Include(e => e.dept).ToList();
        }

        public Employee GetEmp(int id)
        {
            return md.employees.Include(e => e.dept).FirstOrDefault(r=>r.id==id);
        }

        public Employee Add(Employee emp1)
        {
            md.Add(emp1);
            md.SaveChanges();
            return emp1;
        }

        public Employee Update(int id)
        {
            Employee empp = md.employees.Include(e => e.dept).FirstOrDefault(r => r.id == id);
            if (empp is null)
            {
                return null;
            }
            else
            {
            md.Update(empp);
            md.SaveChanges();
            return empp;
            }
            

        }

        public Employee Delete(int id)
        {
            Employee empp=md.employees.Include(e => e.dept).FirstOrDefault(r => r.id == id);
            if (empp is null)
            {
                return null;
            }
            else
            {
                md.Remove(empp);
                md.SaveChanges();
                return empp;
            }
           
        }
    }
}
