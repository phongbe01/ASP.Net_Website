using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTLWeb.Common.Session;
using BTLWeb.Models.Dao;
using BTLWeb.Models.Data;
using BTLWeb.Models.Validate;

namespace BTLWeb.Controllers
{
    
    public class OrderController : Controller
    {
        public double total = 0;

        // GET: Order
        [HttpGet]
        public ActionResult Index()
        {
            var user = Session[Constant.USER_SESSION];
            var cart = Session[Constant.CartSession];
            var list = (List<CartItem>) cart;
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Cart = list;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Order new_order)
        {
            if (ModelState.IsValid)
            {
                var order = new OrderDao();
                order.Insert(new_order);
                CreateOrderDetail(new_order.Id);
                return RedirectToAction("Index", "Home");
            }
            return View("Index");
        }

        public void CreateOrderDetail(int id)
        {
            var cart = Session[Constant.CartSession];
            var order = new OrderDao().GetById(id);
            if (order != null)
            {
                if (cart != null)
                {
                    var list = (List<CartItem>)cart;
                    foreach (var item in list)
                    {
                        var orderDetail = new OrderDetail();
                        orderDetail.OrderId = id;
                        orderDetail.ProductId = item.Product.Id;
                        orderDetail.UnitPrice = item.Product.UnitPrice;
                        orderDetail.Quantity = item.Quantity;
                        var orderDetailDao = new OrderDetailDao();
                        orderDetailDao.Create(orderDetail);
                    }
                }
            }
            Session[Constant.CartSession] = null;
        }
    }
}