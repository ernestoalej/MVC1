using MVC1.Context;
using MVC1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC1.Controllers
{
    public class ProductController : Controller
    {
        private StoreContext db= new StoreContext();

        // GET: Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else { 
                
                var product = db.Products.Find(id);

                if (product == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(product);
                }
            }
        }

        // GET: Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    db.Products.Add(product);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

                return View(product);
            }
            catch
            {
                return View(product);
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {

                var product = db.Products.Find(id);

                if (product == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(product);
                }
            }
           
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid) {

                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");

                } else
                {
                    return View(product);
                   
                }
                
            }
            catch
            {
                return View(product);
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {

                var product = db.Products.Find(id);

                if (product == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(product);
                }
            }

        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                // TODO: Add delete logic here

                if (ModelState.IsValid){

                    product = db.Products.Find(id);

                    if (product == null) {

                        return HttpNotFound();
                    } else { 
                    
                        db.Products.Remove(product);
                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }
                } 
                
                    return View(product);           
                
            }
            catch
            {
                return View();
            }
        }
    }
}
