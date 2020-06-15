using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BTLWeb.Common.Session;
using BTLWeb.Models.Dao;

namespace BTLWeb.Controllers
{
    public class CartController : Controller
    {

        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[Constant.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>) cart;

            }
            return View(list);
        }

        public ActionResult AddItem(int productId, int quantity)
        {
            var product = new ProductDao().GetById(productId);
            var cart = Session[Constant.CartSession];
            double total = 0;
            if (cart != null)
            {
                var list = (List<CartItem>) cart;
                if (list.Exists(x => x.Product.Id == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.Id == productId)
                        {
                            item.Quantity += quantity;
                        }
                        total += item.Quantity * item.Product.UnitPrice;
                        
                    }
                }
                else
                {
                    // create cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                //add item to cart
                Session[Constant.CartSession] = list;
                
            }
            else
            {
                // create cart item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //add item to cart
                Session[Constant.CartSession] = list;
            }

            return Redirect(Request.UrlReferrer.ToString());
        }

        public JsonResult Update(string cartModel)
        {
            var jsoncart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>) Session[Constant.CartSession];
            foreach (var item in sessionCart)
            {
                var jsonItem = jsoncart.SingleOrDefault(x => x.Product.Id == item.Product.Id);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }

            Session[Constant.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Remove(int id)
        {
            var product = new ProductDao().GetById(id);
            var cart = Session[Constant.CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                var item = list.Find(x => x.Product.Id == id);
                list.Remove(item);
                Session[Constant.CartSession] = list;

            }
            return Json( new { status = true});
        }
    }
}