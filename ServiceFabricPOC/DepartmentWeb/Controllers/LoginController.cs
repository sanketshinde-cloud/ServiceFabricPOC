using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentWeb.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (model.UserName == "shri" && model.Password == "shri")
            {
                HttpContext.Session.SetString("Name", model.UserName);
                return RedirectToAction("DashBoard");
            }

            return View();
        }

        public ActionResult DashBoard()
        {
            //if (HttpContext.Session.GetString("Name") != null)
            //{
            return View();
            //}
            //else
            //{
            //    return RedirectToAction("Login");
            //}
        }
    }
}