using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTLWeb.Models.Data;

namespace BTLWeb.Models.Dao
{
    public class OrderDetailDao
    {
        private QLCuaHangDbContext db = null;

        public OrderDetailDao()
        {
            db = new QLCuaHangDbContext();
        }

        public List<OrderDetail> GetByOrderId(int id)
        {
            return db.OrderDetails.Where(x => x.OrderId == id).ToList();
        }

        public void Create(OrderDetail orderDetail)
        {
            db.OrderDetails.Add(orderDetail);
            db.SaveChanges();
        }
    }
}