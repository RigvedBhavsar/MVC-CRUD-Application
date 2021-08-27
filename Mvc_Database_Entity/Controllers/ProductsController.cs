using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Database_Entity.Models;
using System.Net;
//System.Net Will provide some http Status code 

namespace Mvc_Database_Entity.Controllers
{
    public class ProductsController : Controller
    {
        //Creating Instace for Products Context which Enables conection with DB
        ProductsContext db = new ProductsContext();

        //Displaying All Products
        public ViewResult Index()
        {
            return View(db.ProductsTable.ToList());
        }

        //Display Details of Select product
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Product Id Required");
            }
            Product product = db.ProductsTable.Find(id);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product Not Found");
            }
            return View(product);
        }
        //Creating The Product
        public ActionResult Create()
        {
            return View();
        }
        //Creating Action on Controller Create 
        [HttpPost]
        public ActionResult Create(FormCollection frmCollection)
        {
            //Creating Object
            Product prdt = new Product();
            //Collecting Data from the form
            prdt.Name = frmCollection["Name"];
            prdt.Price = Convert.ToDecimal(frmCollection["Price"]);
            db.ProductsTable.Add(prdt);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        //Editing The Record
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Product Id Required");
            }
            Product product = db.ProductsTable.Find(id);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product Not Found");
            }
            return View(product);
        }
        //Creating Action on Edit Controller
        [HttpPost]
        public ActionResult Edit (int id)
        {
            Product product = db.ProductsTable.Find(id);
            UpdateModel(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Deleting the Product
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Product Id Required");
            }
            Product product = db.ProductsTable.Find(id);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product Not Found");
            }
            return View(product);
        }
        //Creating Action on Delete Controller
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Product product = db.ProductsTable.Find(id);
            db.ProductsTable.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}