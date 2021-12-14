using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF_Demo.Models;

namespace EF_Demo.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        public ActionResult Index()
        {
            EFDBFirstDatabaseEntities3 db = new EFDBFirstDatabaseEntities3();
            List<Brand> brands = db.Brands.ToList();
            return View(brands);
        }
    }
}