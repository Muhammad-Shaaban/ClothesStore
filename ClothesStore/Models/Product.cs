using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothesStore.Models
{
    public class Product
    {
        public int id { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public string Prod_Name { get; set; }

        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Size")]
        public int sizeId { get; set; }

        [Required]
        [DisplayName("Price")]
        public string Prod_Price { get; set; }

        [Required]
        [DisplayName("Quantity")]
        public string Prod_Quantity { get; set; }

        [DisplayName("Choose Image ...")]
        public string Prod_Image { get; set; }

        public virtual Category Category { set; get; }
        public virtual size Size { set; get; }

        public virtual ICollection<product_user> product_Users { set; get; }
    }
}