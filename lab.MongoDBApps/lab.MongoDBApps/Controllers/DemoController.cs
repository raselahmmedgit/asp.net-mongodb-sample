using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lab.MongoDBApps.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace lab.MongoDBApps.Controllers
{
    public class DemoController : Controller
    {
        ProductRepository _db = new ProductRepository();

        // GET: CRUD
        public ActionResult Index()
        {
            return View(_db.GetAll());
        }

        // GET: CRUD/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.Get(new ObjectId(id));
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: CRUD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CRUD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Category")] Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Insert(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: CRUD/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.Get(new ObjectId(id));
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: CRUD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Category")] Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: CRUD/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.Get(new ObjectId(id));
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: CRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product product = _db.Get(new ObjectId(id));
            _db.Delete(product);
            return RedirectToAction("Index");
        }

    }
}
