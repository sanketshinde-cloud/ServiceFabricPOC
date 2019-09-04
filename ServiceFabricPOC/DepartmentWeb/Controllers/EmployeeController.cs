using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DepartmentWeb.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Employee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Employee(EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("EmployeeList");
            }
            return View();
        }

        public IActionResult EmployeeList()
        {
            var jsonData = System.IO.File.ReadAllText(@"D:\R And D\DotNetCore\JSON\Employee.json");
            EmployeeObject obj = JsonConvert.DeserializeObject<EmployeeObject>(jsonData);

            List<EmployeeModel> Employee = new List<EmployeeModel>();

            foreach (var test in obj.Employee)
            {
                Employee.Add(test);
            }
            return View(Employee);
        }

        public ActionResult Edit(string id)
        {
            //Fetch data using ID and pass object to view 
            return View("EmployeeList");
        }

        public ActionResult DeleteConfirmed(string id)
        {
            //Delete record using given id and show list page by fetching all records
            return RedirectToAction("EmployeeList");
        }

    }
}