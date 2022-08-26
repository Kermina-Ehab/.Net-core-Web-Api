using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCore.Models
{
    public static class Extensions
    {
        public static EmpDTO EmpToDto(this Employee emp)
        {
            if (emp is not null)
            {
                return new EmpDTO()
                {

                    name = emp.name,
                    age = emp.age,
                    deptname = emp.dept.name
                };
            }
            else return null;
        }

        public static Employee DtoTOEmp(this EmpDTO emp,int deptid)
        {
            if (emp is not null)
            {
                return new Employee()
                {

                    name = emp.name,
                    age = emp.age,
                    deptid = deptid,

                };
            }
            else
            {
                return null;
            }
           
        }
    }
}
