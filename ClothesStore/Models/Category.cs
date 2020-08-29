using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesStore.Models
{
    public class Category
    {
        public int id { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { set; get; }
    }
}