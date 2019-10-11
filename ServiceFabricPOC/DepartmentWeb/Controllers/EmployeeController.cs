using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
                if (employeeModel.EmpId == 0)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = client.PostAsJsonAsync("http://localhost:8426/api/Employee", employeeModel).Result;
                        var jsondata = response.Content.ReadAsStringAsync().Result;
                        EmployeeObject obj = JsonConvert.DeserializeObject<EmployeeObject>(jsondata);
                        List<EmployeeModel> Employee = new List<EmployeeModel>();
                        foreach (var test in obj.Employees)
                        {
                            Employee.Add(test);
                        }
                        return View("EmployeeList", Employee);
                    }

                }
                else
                {
                    //Update to DB;

                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = client.PutAsJsonAsync("http://localhost:8426/api/Employee/" + employeeModel.EmpId, employeeModel).Result;
                        var jsondata = response.Content.ReadAsStringAsync().Result;
                        EmployeeObject obj = JsonConvert.DeserializeObject<EmployeeObject>(jsondata);
                        List<EmployeeModel> Employee = new List<EmployeeModel>();
                        foreach (var test in obj.Employees)
                        {
                            Employee.Add(test);
                        }
                        return View("EmployeeList", Employee);
                    }

                }
            }
            return null;
        }

        public IActionResult EmployeeList()
        {

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync("http://localhost:8426/api/Employee").Result;
                var jsondata = response.Content.ReadAsStringAsync().Result;
                EmployeeObject obj = JsonConvert.DeserializeObject<EmployeeObject>(jsondata);
                List<EmployeeModel> Employee = new List<EmployeeModel>();
                foreach (var test in obj.Employees)
                {
                    Employee.Add(test);
                }
                return View(Employee);
            }
        }

        public ActionResult Edit(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync("http://localhost:8426/api/Employee/" + id).Result;
                var jsondata = response.Content.ReadAsStringAsync().Result;
                EmployeeModel obj = JsonConvert.DeserializeObject<EmployeeModel>(jsondata);

                return View("Employee", obj);
            }
        }

        public ActionResult Delete(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.DeleteAsync("http://localhost:8426/api/Employee/" + id).Result;
                var jsondata = response.Content.ReadAsStringAsync().Result;
                EmployeeObject obj = JsonConvert.DeserializeObject<EmployeeObject>(jsondata);
                List<EmployeeModel> Employee = new List<EmployeeModel>();
                foreach (var test in obj.Employees)
                {
                    Employee.Add(test);
                }
                return View("EmployeeList", Employee);
            }
        }

    }
}