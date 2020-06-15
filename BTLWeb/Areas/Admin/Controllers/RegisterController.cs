using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTLWeb.Common.Session;
using BTLWeb.Models.Data;

namespace BTLWeb.Areas.Admin.Controllers
{
    public class RegisterController : Controller
    {
        private QLCuaHangDbContext db = new QLCuaHangDbContext();
        // GET: Admin/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "UserName,Password,Fullname,Email,Photo")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                var userSession = new UserSession();
                userSession.UserName = customer.UserName;
                Session.Add(Constant.USER_SESSION, userSession);
                return RedirectToAction("Index", "Home", new { Area = "" });
            }

            return View(customer);
        }
    }
}