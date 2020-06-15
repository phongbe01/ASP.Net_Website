using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.FrameWork;

namespace Models
{
    public class AccountModel
    {
        private AccountDbContext context = null;

        public AccountModel()
        {
            context = new AccountDbContext();
        }

        public bool Login(string email, string password)
        {
            object[] sqlParameters =
            {
                new SqlParameter("@email", email),
                new SqlParameter("@password", password),
            };
            var res = context.Database.SqlQuery<bool>("account_login @email, @password", sqlParameters).SingleOrDefault();
            return res;
        }
    }
}
