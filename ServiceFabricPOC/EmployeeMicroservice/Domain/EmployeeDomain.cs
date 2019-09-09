using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMicroservice.Domain
{
    public class EmployeeDomain
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int? EmpAge { get; set; }
        public string EmpSalary { get; set; }
        public string EmpEmail { get; set; }
    }
}
