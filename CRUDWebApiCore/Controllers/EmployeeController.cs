using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDWebApiCore.Model;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUDWebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        db dbop = new db();
        string msg = string.Empty;
        // GET: api/<EmployeeController>
        [HttpGet]
        public List<Employee> Get()
        {
            Employee emp = new Employee();
            emp.type = "get";
            DataSet ds = dbop.EmployeeGet(emp, out msg);
            List<Employee> list = new List<Employee>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Employee
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Email = dr["Email"].ToString(),
                    Emp_name = dr["Emp_name"].ToString(),
                    Designation = dr["Designation"].ToString()
                }) ;
            }
            return list;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public List<Employee> Get(int id)
        {
            Employee emp = new Employee();
            emp.Id = id;
            emp.type = "getId";
            DataSet ds = dbop.EmployeeGet(emp, out msg);
            List<Employee> list = new List<Employee>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Employee
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Email = dr["Email"].ToString(),
                    Emp_name = dr["Emp_name"].ToString(),
                    Designation = dr["Designation"].ToString()
                });
            }
            return list;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public string Post([FromBody] Employee emp)
        {
            string msg = string.Empty;
            try
            {
                msg = dbop.EmployeeOpt(emp);
            }
            catch (Exception ee)
            {
                msg = ee.Message;
            }
            return msg;
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public string Update([FromBody] Employee emp)
        {
            string msg = string.Empty;
            try
            {
                emp.type = "update";
                msg = dbop.EmployeeOpt(emp);
            }
            catch (Exception ee)
            {
                msg = ee.Message;
            }
            return msg;
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string msg = string.Empty;
            try
            {
                Employee emp = new Employee();
                emp.Id = id;
                emp.type = "delete";
                msg = dbop.EmployeeOpt(emp);
            }
            catch (Exception ee)
            {
                msg = ee.Message;
            }
            return msg;
        }
    }
}
