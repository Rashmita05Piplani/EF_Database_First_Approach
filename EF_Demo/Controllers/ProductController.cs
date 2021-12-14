using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF_Demo.Models;

namespace EF_Demo.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index( )  //Sorting of columns based on input that's why parameters
        {
            EFDBFirstDatabaseEntities3 db = new EFDBFirstDatabaseEntities3();
            List<Product> products = db.Products.ToList();
            //ViewBag.SortColumn = SortColumn;
            //ViewBag.IconClass = IconClass;
            //if(ViewBag.SortColumn=="ProductId")

            return View(products);
        }
        [HttpGet]
        public ActionResult SearchProducts()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchProducts(string NameOfBrand)
         {
            EFDBFirstDatabaseEntities3 db = new EFDBFirstDatabaseEntities3();
            List<Product> products = db.Products.Where(temp=>temp.ProductName.Contains(NameOfBrand)).ToList();
            return View("Index",products);
        } 
        public ActionResult Details(long id)
        {
            EFDBFirstDatabaseEntities3 db = new EFDBFirstDatabaseEntities3();
            Product p = db.Products.Where(temp => temp.ProductId == id).FirstOrDefault();
            return View(p);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            EFDBFirstDatabaseEntities3 db = new EFDBFirstDatabaseEntities3();
            if(Request.Files.Count>=1)
            {
                var file = Request.Files[0];
                var imgBytes = new Byte[file.ContentLength - 1];
                file.InputStream.Read(imgBytes, 0, file.ContentLength);
                var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
               // p.Photo = base64String;

            }
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
            

        }
        public ActionResult Edit(long id)
        {
            EFDBFirstDatabaseEntities3 db = new EFDBFirstDatabaseEntities3();
            Product existingProduct = db.Products.Where(temp => temp.ProductId == id).FirstOrDefault();
            return View(existingProduct);


        }
        [HttpPost]
        public ActionResult Edit(Product p
            )
        {
            EFDBFirstDatabaseEntities3 db = new EFDBFirstDatabaseEntities3();
            Product existingProduct = db.Products.Where(temp => temp.ProductId == p.ProductId).FirstOrDefault();
            existingProduct.ProductName = p.ProductName;
            existingProduct.Price = p.Price;
            existingProduct.DateOfPurchase = p.DateOfPurchase;
            existingProduct.CategoryId = p.CategoryId;
            existingProduct.BrandID = p.BrandID;
            existingProduct.AvailabiltyStatus = p.AvailabiltyStatus;
            existingProduct.Active = p.Active;
            db.SaveChanges();
            return RedirectToAction("Index","Product");

        }
        public ActionResult Delete(long id)
        {
            EFDBFirstDatabaseEntities3 db = new EFDBFirstDatabaseEntities3();
            Product existingProduct = db.Products.Where(temp => temp.ProductId == id).FirstOrDefault();
            return View(existingProduct);
        }
        [HttpPost]

        public ActionResult Delete(long id,Product p)
        {
            EFDBFirstDatabaseEntities3 db = new EFDBFirstDatabaseEntities3();
            Product existingProduct = db.Products.Where(temp => temp.ProductId == id).FirstOrDefault();
            db.Products.Remove(existingProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}