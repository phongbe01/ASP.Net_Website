using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BTLWeb.Models.Data;

namespace BTLWeb.Areas.Admin.Models.Dao
{
    public class ProductDao
    {
        private QLCuaHangDbContext db = null;

        public ProductDao()
        {
            db = new QLCuaHangDbContext();
        }

        public List<Product> All()
        {
            return db.Products.ToList();
        }

        public void Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public Product FindById(int id)
        {
            return db.Products.Find(id);
        }

        public void Update(int id, Product product)
        {
            var pr = FindById(id);
            pr.Quantity = product.Quantity;
            pr.UnitPrice = product.UnitPrice;
            pr.Image = product.Image;
            pr.Discount = product.Discount;
            pr.Name = product.Name;
            pr.CategoryId = product.CategoryId;
            pr.ProductDate = product.ProductDate;
        }

        public void Delete(int id)
        {
            var pr = FindById(id);
            db.Entry(pr).State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}