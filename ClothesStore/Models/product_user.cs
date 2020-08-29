using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesStore.Models
{
    public class product_user
    {
        public int id { get; set; }
        public int ProductId { get; set; }
        public string User_id { get; set; }
        public int Product_Quantity { get; set; }
        public int Prodcut_Price { get; set; }
        public int Product_totalPrice { get; set; }

        public virtual Product Product { get; set; }
    }
}