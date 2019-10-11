using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DepartmentWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DepartmentWeb.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Departmentcreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Departmentcreate(DepartmentModel department)
        {
            if (ModelState.IsValid)
            {
                if (department.DeptId == null)
                {
                    //Save to DB;
                    department.DeptId = "0";

                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = client.PostAsJsonAsync("http://localhost:8852/api/Departments/", department).Result;
                        var jsondata = response.Content.ReadAsStringAsync().Result;
                        RootObject obj = JsonConvert.DeserializeObject<RootObject>(jsondata);
                        List<DepartmentModel> departments = new List<DepartmentModel>();
                        foreach (var test in obj.Department)
                        {
                            departments.Add(test);
                        }
                        return View("DepartmentList", departments);
                    }

                }
                else
                {
                    //Update to DB;

                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = client.PutAsJsonAsync("http://localhost:8852/api/Departments/" + department.DeptId, department).Result;
                        var jsondata = response.Content.ReadAsStringAsync().Result;
                        RootObject obj = JsonConvert.DeserializeObject<RootObject>(jsondata);
                        List<DepartmentModel> departments = new List<DepartmentModel>();
                        foreach (var test in obj.Department)
                        {
                            departments.Add(test);
                        }
                        return View("DepartmentList", departments);
                    }

                }
            }
            return null;

        }

        public IActionResult DepartmentList()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync("http://localhost:8852/api/Departments").Result;
                var jsondata = response.Content.ReadAsStringAsync().Result;
                RootObject obj = JsonConvert.DeserializeObject<RootObject>(jsondata);
                List<DepartmentModel> departments = new List<DepartmentModel>();
                foreach (var test in obj.Department)
                {
                    departments.Add(test);
                }
                return View(departments);
            }
        }

        public ActionResult Edit(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync("http://localhost:8852/api/Departments/" + id).Result;
                var jsondata = response.Content.ReadAsStringAsync().Result;
                DepartmentModel obj = JsonConvert.DeserializeObject<DepartmentModel>(jsondata);

                return View("Departmentcreate", obj);
            }
        }

        public ActionResult Delete(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.DeleteAsync("http://localhost:8852/api/Departments/" + id).Result;
                var jsondata = response.Content.ReadAsStringAsync().Result;
                RootObject obj = JsonConvert.DeserializeObject<RootObject>(jsondata);
                List<DepartmentModel> departments = new List<DepartmentModel>();
                foreach (var test in obj.Department)
                {
                    departments.Add(test);
                }
                return View("DepartmentList", departments);
            }
        }

    }
}