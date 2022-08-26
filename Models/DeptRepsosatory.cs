using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCore.Models
{
    public interface IiDeptRepository
    {
        int GetDept(EmpDTO emp1);
        
    }
    public class DeptRepsosatory:IiDeptRepository
    {
        readonly Model md1;
        public DeptRepsosatory(Model md1)
        {
            this.md1 = md1;
        }

        public int GetDept(EmpDTO emp1)
        {
            return md1.departments.Where(e => e.name == emp1.deptname).FirstOrDefault().id;
        }
    }
}
