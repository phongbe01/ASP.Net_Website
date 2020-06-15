using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BTLWeb.Models.Data;

namespace BTLWeb.Models.Dao
{
    public class CustomDao
    {
        private QLCuaHangDbContext db = null;

        public CustomDao()
        {
            db = new QLCuaHangDbContext();
        }

        public Customer GetCustomer(string userName)
        {
            return db.Customers.Where(x => x.UserName == userName).SingleOrDefault();
        }

        public bool Login(string userName, string password)
        {
            object[] sqlParameters =
                {
                    new SqlParameter("@username", userName),
                    new SqlParameter("@password", password),
                };
                var res = db.Database.SqlQuery<bool>("login_account @username, @password", sqlParameters).SingleOrDefault();
                return res;
        }

        public bool isAdmin(Customer user)
        {
            object[] sqlParameters =
            {
                new SqlParameter("@username", user.UserName),
                new SqlParameter("@password", user.Password),
            };
            var res = db.Database.SqlQuery<bool>("is_admin @username, @password", sqlParameters).SingleOrDefault();
            return res;
        }

        public void Update(string username, Customer cus)
        {
            var customer = GetCustomer(username);
            customer.UserName = cus.UserName;
            customer.Password = cus.Password;
            customer.Email = cus.Email;
            customer.Photo = cus.Photo;
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}