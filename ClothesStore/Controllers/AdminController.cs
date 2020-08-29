using ClothesStore.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesStore.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        ApplicationDbContext _db = new ApplicationDbContext();

        // Create New Role


        // GET: Admin
        public ActionResult Index()
        {
            if (User.Identity.Name == "womenflower")
            {
                return View(_db.Products.ToList());
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_db.Categories, "id", "CategoryName");
            ViewBag.sizeId = new SelectList(_db.Sizes, "id", "SizeName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product model, HttpPostedFileBase upload)
        {
            if(ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);

                model.Prod_Image = upload.FileName;

                _db.Products.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(_db.Categories, "id", "CategoryName", model.CategoryId);
            ViewBag.sizeId = new SelectList(_db.Sizes, "id", "SizeName", model.sizeId);
            return View(model); ;
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = _db.Products.Find(id);

            ViewBag.CategoryId = new SelectList(_db.Categories, "id", "CategoryName", item.CategoryId);
            ViewBag.sizeId = new SelectList(_db.Sizes, "id", "SizeName", item.sizeId);

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Product model, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string oldPath = Path.Combine(Server.MapPath("~/Uploads"), model.Prod_Image);

                if (upload != null)
                {
                    string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                    System.IO.File.Delete(oldPath);

                    upload.SaveAs(path);
                    model.Prod_Image = upload.FileName;
                }

                _db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(_db.Categories, "id", "CategoryName", model.CategoryId);
            ViewBag.sizeId = new SelectList(_db.Sizes, "id", "SizeName", model.sizeId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Product item = _db.Products.Find(id);
            _db.Products.Remove(item);

            //Delete Image
            if (item.Prod_Image != null)
            {
                string oldPath = Path.Combine(Server.MapPath("~/Uploads"), item.Prod_Image);
                System.IO.File.Delete(oldPath);
            }
            

            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}