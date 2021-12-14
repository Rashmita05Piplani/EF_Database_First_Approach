using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF_Demo.Models;

namespace EF_Demo.Controllers
{
    public class CategoryController : Controller 
    {    // GET: Category
        public ActionResult Index()
        {
            EFDBFirstDatabaseEntities3 db = new EFDBFirstDatabaseEntities3();

             List<Category> categories=db.Categories.ToList();
            return View(categories);
        }
    }
}