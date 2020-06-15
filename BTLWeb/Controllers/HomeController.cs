using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTLWeb.Common.Session;
using BTLWeb.Models.Dao;

namespace BTLWeb.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var topView = new ProductDao().GetByViews();
            ViewBag.DisCount = new ProductDao().GetByDisCount();
            ViewBag.Categories = new CategoryDao().CategoriesList();
            return View(topView);
        }

        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[Constant.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;

            }

            return PartialView(list);
        }

        [HttpGet]
        public ActionResult Search(string key)
        {
            var products = new ProductDao().GetProductsByName(key);
            if (products.Count == 0)
            {
                return Redirect("~/Error/Error");
            }
            return View(products);
        }

    }
}