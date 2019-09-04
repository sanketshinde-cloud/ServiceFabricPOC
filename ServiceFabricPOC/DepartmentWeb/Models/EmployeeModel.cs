using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentWeb.Models
{
    public class EmployeeModel
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
        public string EMail { get; set; }
    }

    public class EmployeeObject
    {
        public List<EmployeeModel> Employee { get; set; }
    }
}
