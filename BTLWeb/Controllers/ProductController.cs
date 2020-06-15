using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTLWeb.Models.Dao;
using PagedList;
using PagedList.Mvc;

namespace BTLWeb.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        public ActionResult Index(int categoryId, int? page)
        {
            int pageSize = 12; // numbers of products per page 
            int pageNumber = (page ?? 1);
            var products = new ProductDao().GetByCategory(categoryId).ToPagedList(pageNumber, pageSize);
            var banner = new CategoryDao().GetById(categoryId);
            ViewBag.BannerImage = banner.Image;
            ViewBag.Name = banner.NameVN;
            return View(products);
        }

        public ActionResult ProductDetail(int productId)
        {
            var product = new ProductDao();
            var productDetail = product.GetById(productId);
            var categoryId = productDetail.CategoryId;
            var relatedProducts = product.RelatedProducts(categoryId);
            ViewBag.RelatedProducts = relatedProducts;
            return View(productDetail);
        }

    }
}