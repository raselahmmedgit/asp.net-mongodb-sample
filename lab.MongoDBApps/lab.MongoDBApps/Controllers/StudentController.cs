using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lab.MongoDBApps.Models;
using MongoDB.Bson;

namespace lab.MongoDBApps.Controllers
{
    public class StudentController : Controller
    {
        StudentRepository _db = new StudentRepository();

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
            Student student = _db.Get(new ObjectId(id));
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
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
        public ActionResult Create([Bind(Include = "StudentId,StudentName,Price,Category")] Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Insert(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: CRUD/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = _db.Get(new ObjectId(id));
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: CRUD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,StudentName,Price,Category")] Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Update(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: CRUD/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = _db.Get(new ObjectId(id));
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: CRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Student student = _db.Get(new ObjectId(id));
            _db.Delete(student);
            return RedirectToAction("Index");
        }

    }
}
