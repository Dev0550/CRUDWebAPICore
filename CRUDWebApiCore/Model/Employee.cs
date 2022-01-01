using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWebApiCore.Model
{
    public class Employee
    {
        public int Id { get; set; } = 0;
        public string Email { get; set; } = "";
        public string Emp_name { get; set; } = "";
        public string Designation { get; set; } = "";
        public string type { get; set; } = "";
    }
}
