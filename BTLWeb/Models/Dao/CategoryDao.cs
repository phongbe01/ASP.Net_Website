using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTLWeb.Models.Data;

namespace BTLWeb.Models.Dao
{
    public class CategoryDao
    {
        private QLCuaHangDbContext db = null;

        public CategoryDao()
        {
            db = new QLCuaHangDbContext();
        }

        public List<Category> CategoriesList()
        {
            return db.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return db.Categories.Where(x => x.Id == id).SingleOrDefault();
        }
    }
}