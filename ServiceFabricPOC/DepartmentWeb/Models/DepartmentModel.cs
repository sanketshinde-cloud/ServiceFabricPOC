using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentWeb.Models
{
    public class DepartmentModel
    {
        public string DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptDescription { get; set; }
        public string EmployeeCount { get; set; }
        public string ShiftTime { get; set; }
    }
    public class RootObject
    {
        public List<DepartmentModel> Department { get; set; }
    }
    public class Name
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
}
