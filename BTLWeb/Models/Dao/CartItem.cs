using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTLWeb.Models.Data;

namespace BTLWeb.Models.Dao
{
    [Serializable]
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public double Toal()
        {
            return Product.UnitPrice * Quantity;
        }

    }
}