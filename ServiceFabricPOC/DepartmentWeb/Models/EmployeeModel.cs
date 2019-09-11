using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentWeb.Models
{
    public class EmployeeModel
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int? EmpAge { get; set; }
        public string EmpSalary { get; set; }
        public string EmpEmail { get; set; }
    }

    public class EmployeeObject
    {
        public List<EmployeeModel> Employees { get; set; }
    }
}
