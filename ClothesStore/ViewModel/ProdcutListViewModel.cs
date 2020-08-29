using ClothesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesStore.ViewModel
{
    public class ProdcutListViewModel
    {
        public List<Product> wedding_List { get; set; }
        public List<Product> jeans_List { get; set; }
        public List<Product> underwear_List { get; set; }
        public List<Product> jilbab_List { get; set; }
    }
}