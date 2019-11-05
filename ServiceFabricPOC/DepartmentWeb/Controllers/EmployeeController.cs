using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DepartmentWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace DepartmentWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private IDistributedCache _cache;

        public EmployeeController(IDistributedCache cache)
        {
            _cache = cache;
        }

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
            //Testing of cache...

            //string value = _cache.GetString("CacheTime");

            //if (value == null)
            //{
            //    value = DateTime.Now.ToString();
            //    var options = new DistributedCacheEntryOptions();
            //    options.SetSlidingExpiration(TimeSpan.FromMinutes(1));
            //    _cache.SetString("CacheTime", value, options);
            //}

            //string test1 = value;



            ////////////using (HttpClient client = new HttpClient())
            ////////////{
            ////////////    HttpResponseMessage response = client.GetAsync("http://localhost:8426/api/Employee").Result;
            ////////////    var jsondata = response.Content.ReadAsStringAsync().Result;
            ////////////    EmployeeObject obj = JsonConvert.DeserializeObject<EmployeeObject>(jsondata);
            ////////////    List<EmployeeModel> Employee = new List<EmployeeModel>();
            ////////////    foreach (var test in obj.Employees)
            ////////////    {
            ////////////        Employee.Add(test);
            ////////////    }
            ////////////    return View(Employee);
            ////////////}


            var value = _cache.GetString("EmployeeData");
            if (value != null)
            {
                //var EmployeeCache = JsonConvert.DeserializeObject(value);
                List<EmployeeModel> EmployeeCache = JsonConvert.DeserializeObject<List<EmployeeModel>>(value);

                return View(EmployeeCache);
            }
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

                var options = new DistributedCacheEntryOptions();
                options.SetSlidingExpiration(TimeSpan.FromMinutes(1));
                _cache.SetString("EmployeeData", JsonConvert.SerializeObject(Employee), options);

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