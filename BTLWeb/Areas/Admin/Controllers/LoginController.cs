using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTLWeb.Areas.Admin;
using BTLWeb.Common.Session;
using BTLWeb.Models.Dao;
using BTLWeb.Models.Validate;

namespace BTLWeb.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginValidate val)
        {
            if (ModelState.IsValid)
            {
                var model = new CustomDao();
                var res = model.Login(val.UserName, val.Password);
                if (res)
                {
                    var user = model.GetCustomer(val.UserName);
                    var userSession = new UserSession();
                    userSession.UserName = user.UserName;
                    Session.Add(Constant.USER_SESSION, userSession);
                    if (model.isAdmin(user))
                    {
                        return RedirectToAction("Index", "AdminHome");
                    }

                    return RedirectToAction("Index", "Home", new { Area = ""});
                }
            }
            else
            {
                ModelState.AddModelError("","email or password is not correct");
            }
            
            return View();
        }

        public ActionResult LogOut()
        {
            Session[Constant.USER_SESSION] = null;
            return RedirectToAction("Index", "Home", new {Area = ""});
        }
    }
}