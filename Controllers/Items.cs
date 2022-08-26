using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using ApiCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Items : ControllerBase
    {

        readonly IitemsRepository iitems;
        readonly IiDeptRepository idept;

        public Items(IitemsRepository Irep, IiDeptRepository Idept)
        {
            iitems = Irep;
            this.idept = Idept;
        }
        [HttpGet]
        public IActionResult Getemps()
        {
            List<EmpDTO> emps = iitems.GetEmps().Select(e => e.EmpToDto()).ToList();
            return Ok(emps);
        }

        [HttpGet("{id:int}",Name = "GetEMp")]
        public IActionResult Getemp(int id)
        {
            EmpDTO emp = iitems.GetEmp(id).EmpToDto();

            if (emp is null)
            {
                return BadRequest(); ///is it true? or no content
                
            }
            return Ok(emp);
        }

        [HttpPost]
        public IActionResult Addemp(EmpDTO emp1)
        {


            int deptid=idept.GetDept(emp1);

            Employee emp = emp1.DtoTOEmp(deptid);
            iitems.Add(emp);

            var link = Url.Link("GetEMp", new { id = emp.id });

            return Created(link, emp1);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Deleteemp(int id)
        {
            EmpDTO emp1=iitems.Delete(id).EmpToDto();
            if (emp1 is null)
            {
                return NotFound();
            }
            else {
              
                return Ok(emp1);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Updateemp(int id,EmpDTO emp)
        {
           

            Employee emp1 = iitems.GetEmp(id);
            if (emp1 is null)
            {
                return NotFound();
            }
            else
            {
                emp1.name = emp.name;
                emp1.age = emp.age;
                emp1.deptid = idept.GetDept(emp);

                EmpDTO empDt = iitems.Update(emp1.id).EmpToDto();
                if (empDt is null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(empDt);
                }
            };
        }



    }
}
