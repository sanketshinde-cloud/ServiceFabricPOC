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


                //using (HttpClient client = new HttpClient())
                //{
                //    var myContent = JsonConvert.SerializeObject(department);
                //    var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                //    var byteContent = new ByteArrayContent(buffer);
                //    try
                //    {
                //        HttpResponseMessage response = client.PostAsync("https://feed-api.gumtree.com/api/users/login", byteContent).Result;
                //        response.EnsureSuccessStatusCode();
                //        string responseBody = response.Content.ReadAsStringAsync().Result;
                //    }
                //    catch (HttpRequestException e)
                //    {
                //        Console.WriteLine("\nException Caught!");
                //        Console.WriteLine("Message :{0} ", e.Message);
                //    }
                    //Need to add code to pass data to save API
                //}
                return RedirectToAction("DepartmentList");
            }

            return View("Departmentcreate");
        }

        public IActionResult DepartmentList()
        {
            //using (HttpClient client = new HttpClient())
            //{

            //    HttpResponseMessage response = client.GetAsync("http://www.7timer.info/bin/astro.php?lon=113.17&lat=23.09&ac=0&lang=en&unit=metric&output=internal&tzshift=0").Result;
            //    var test = response;
            //}
            //here needs to return JSON in view

            var jsonData = System.IO.File.ReadAllText(@"D:\R And D\DotNetCore\JSON\Test.json");
            RootObject obj = JsonConvert.DeserializeObject<RootObject>(jsonData);

            List<DepartmentModel> departments = new List<DepartmentModel>();

            foreach (var test in obj.Department)
            {
                departments.Add(test);
            }
            return View(departments);
        }

        public ActionResult Edit(string id)
        {
            //Fetch data using ID and pass object to view 
            return View("DepartmentList");
        }

        public ActionResult DeleteConfirmed(string id)
        {
            //Delete record using given id and show list page by fetching all records
            return RedirectToAction("DepartmentList");
        }

    }
}