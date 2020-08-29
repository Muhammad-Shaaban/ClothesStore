using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesStore.ViewModel
{
    public class CartViewModel
    {
        public int product_id { get; set; }
        public string UserId { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int totalPrice { get; set; }
    }
}