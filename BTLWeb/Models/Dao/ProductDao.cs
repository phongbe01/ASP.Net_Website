using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTLWeb.Models.Data;

namespace BTLWeb.Models.Dao
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

        public List<Product> GetByCategory(int categoryId)
        {
            return db.Products.Where(x => x.CategoryId == categoryId).ToList();
        }

        public Product GetById(int id)
        {
            return db.Products.Where(x => x.Id == id).SingleOrDefault();
        }

        public List<Product> RelatedProducts(int categoryId)
        {
            return db.Products.Where(x => x.CategoryId == categoryId).Take(4).ToList();
        }

        public List<Product> GetByViews()
        {
            return db.Products.OrderByDescending(x => x.Views).Take(4).ToList();
        }

        public List<Product> GetByDisCount()
        {
            return db.Products.OrderByDescending(x => x.Discount).Take(4).ToList();
        }

        public List<Product> GetProductsByName(string keyword)
        {
            return db.Products.Where(i => i.Name.Contains(keyword)).ToList();
        }
    }
}