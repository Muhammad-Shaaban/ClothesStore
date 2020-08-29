using ClothesStore.Models;
using ClothesStore.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesStore.Controllers
{
    public class HomeController : Controller
    {

        ApplicationDbContext _db = new ApplicationDbContext();

        public HomeController()
        {
            
        }

        public ActionResult Index()
        {
            var ViewList = new ProdcutListViewModel();

            ViewList.wedding_List = _db.Products.Where(e => e.Category.CategoryName == "Wedding").ToList();
            ViewList.jeans_List = _db.Products.Where(e => e.Category.CategoryName == "Jeans").ToList();
            ViewList.underwear_List = _db.Products.Where(e => e.Category.CategoryName == "UnderWear").ToList();
            ViewList.jilbab_List = _db.Products.Where(e => e.Category.CategoryName == "Jilbab").ToList();

            return View(ViewList);
        }

        // Start get Collection and Filter Product [Price - Alphabetically - Date]
        public ActionResult Collection(string collection, int? filterType)
        {
            // Filter By Collection
            //======================
            // 1- wedding
            // 2- jeans
            // 3- underwear
            // 4- jilbab

            // Filter By [Price - Alphabetically - Date]
            // 1- Price_L_H
            // 2- Price_H_L
            // 3- Alphabeti_A_Z
            // 4- Alphabeti_Z_A
            // 5- Size_S
            // 6- Size_M
            // 7- Size_L
            // 8- Size_XL
            // 9- Size_2XL
            // 10- Size_3XL
            // 11- Size_4XL

            ViewBag.CollectionName = collection;

            var allProds = _db.Products.Where(e => e.Category.CategoryName == collection).ToList();

            if (filterType == 1)
            {
                return View(allProds.OrderBy(e => e.Prod_Price).ToList());
            }

            else if (filterType == 2)
            {
                return View(allProds.OrderByDescending(e => e.Prod_Price).ToList());
            }

            else if (filterType == 3)
            {
                return View(allProds.OrderBy(e => e.Prod_Name).ToList());
            }

            else if (filterType == 4)
            {
                return View(allProds.OrderByDescending(e => e.Prod_Name).ToList());
            }

            else if (filterType == 5)
            {
                return View(allProds.Where(e => e.Size.SizeName == "s"));
            }

            else if (filterType == 6)
            {
                return View(allProds.Where(e => e.Size.SizeName == "m"));
            }

            else if (filterType == 7)
            {
                return View(allProds.Where(e => e.Size.SizeName == "l"));
            }

            else if (filterType == 8)
            {
                return View(allProds.Where(e => e.Size.SizeName == "xl"));
            }

            else if (filterType == 9)
            {
                return View(allProds.Where(e => e.Size.SizeName == "2xl"));
            }

            else if (filterType == 10)
            {
                return View(allProds.Where(e => e.Size.SizeName == "3xl"));
            }

            else if (filterType == 11)
            {
                return View(allProds.Where(e => e.Size.SizeName == "4xl"));
            }

            else
            {
                return View(allProds);
            }

        }

        // Add Products to Cart
        [HttpPost]
        [Authorize]
        public ActionResult addToCart(int productID, int productQuantity, int productPrice, int productTotalPrice, string ProductCategory)
        {
            var newCart = new product_user()
            {
                ProductId = productID,
                Product_Quantity = productQuantity,
                Prodcut_Price = productPrice,
                Product_totalPrice = productTotalPrice,
                User_id = User.Identity.GetUserId()
            };

            _db.product_Users.Add(newCart);
            _db.SaveChanges();

            return RedirectToAction("Collection", new { collection = ProductCategory });
        }


        [HttpGet]
        [Authorize]
        public ActionResult Cart()
        {
            var totalCartPrice = 0;
            var currentUser = User.Identity.GetUserId();
            var prodcutsUserCart = _db.product_Users.Where(e => e.User_id == currentUser).ToList();

            foreach(var item in prodcutsUserCart)
            {
                totalCartPrice += item.Product_totalPrice;
            }

            ViewBag.totalCart = totalCartPrice;

            return View(prodcutsUserCart);
        }

        [HttpGet]
        [Authorize]
        public ActionResult UpdateCart(int id, int newQuantity)
        {
            var currentCart = _db.product_Users.SingleOrDefault(e => e.id == id);
            var newTotalPrice = currentCart.Prodcut_Price * newQuantity;

            currentCart.Product_Quantity = newQuantity;
            currentCart.Product_totalPrice = newTotalPrice;
            _db.SaveChanges(); 
                
            // get products after update for authenticted user
            var totalPriceForUser = 0;
            var currentUser = User.Identity.GetUserId();
            var ProductsForAuthUser = _db.product_Users.Where(e => e.User_id == currentUser);

            foreach (var item in ProductsForAuthUser)
            {
                totalPriceForUser += item.Product_totalPrice;
            }

            return Json(new { total = currentCart.Product_totalPrice, totalForUser = totalPriceForUser }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteCurrentCart(int id)
        {
            var currentPordCart = _db.product_Users.SingleOrDefault(e => e.id == id);

            _db.product_Users.Remove(currentPordCart);
            _db.SaveChanges();

            return RedirectToAction("Cart");
        }

        public ActionResult getAllProductsInCart()
        {
            var totalCartPrice = 0;
            var currentUser = User.Identity.GetUserId();
            var prodcutsUserCart = _db.product_Users.Where(e => e.User_id == currentUser).ToList();

            foreach (var item in prodcutsUserCart)
            {
                totalCartPrice += item.Product_totalPrice;
            }

            ViewBag.totalCartForBasket = totalCartPrice;
            
            // Get Total Count of Products in cart for current user
            ViewBag.totalCartCount = _db.product_Users.Where(E => E.User_id == currentUser).Count();

            return PartialView("_cartBasket", prodcutsUserCart);
        }

        public ActionResult DeleteFromBasket(int id)
        {
            var currentPordCart = _db.product_Users.SingleOrDefault(e => e.id == id);

            _db.product_Users.Remove(currentPordCart);
            _db.SaveChanges();

            return Json(new { }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Payment()
        {
            
            return View();
        }
    }
}