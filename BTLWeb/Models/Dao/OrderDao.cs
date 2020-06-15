using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTLWeb.Models.Data;

namespace BTLWeb.Models.Dao
{
    public class OrderDao
    {
        private QLCuaHangDbContext db = null;

        public OrderDao()
        {
            db = new QLCuaHangDbContext();
        }

        public List<Order> GetByUserId(string id)
        {
            return db.Orders.Where(x => x.CustomerId == id).ToList();
        }

        public void Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public Order GetById(int id)
        {
            return db.Orders.Where(x => x.Id == id).SingleOrDefault();
        }
    }
}