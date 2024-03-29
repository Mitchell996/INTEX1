﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using INTEX.DAL;
using INTEX.Models;

namespace INTEX.Controllers
{
    public class TestsController : Controller
    {
        private INTEXContext db = new INTEXContext();

        // GET: Tests
        public ActionResult Index()
        {
            var test = db.Test.Include(t => t.Employee).Include(t => t.Tes);
            return View(test.ToList());
        }

        // GET: Tests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Test.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: Tests/Create
        public ActionResult Create()
        {
            ViewBag.EMPLOYEEID = new SelectList(db.Employee, "EMPLOYEEID", "EMPFIRSTNAME");
            ViewBag.TESTCONDITIONAL = new SelectList(db.Test, "TESTID", "TESTDESCRIPTION");
            return View();
        }

        // POST: Tests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TESTID,EMPLOYEEID,HOURSTOCOMPLETE,BASEPRICE,NUMBEROFDAYS,TESTDESCRIPTION,PROGRESS,TESTCONDITIONAL")] Test test)
        {
            if (ModelState.IsValid)
            {
                db.Test.Add(test);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EMPLOYEEID = new SelectList(db.Employee, "EMPLOYEEID", "EMPFIRSTNAME", test.EMPLOYEEID);
            ViewBag.TESTCONDITIONAL = new SelectList(db.Test, "TESTID", "TESTDESCRIPTION", test.TESTCONDITIONAL);
            return View(test);
        }

        // GET: Tests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Test.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMPLOYEEID = new SelectList(db.Employee, "EMPLOYEEID", "EMPFIRSTNAME", test.EMPLOYEEID);
            ViewBag.TESTCONDITIONAL = new SelectList(db.Test, "TESTID", "TESTDESCRIPTION", test.TESTCONDITIONAL);
            return View(test);
        }

        // POST: Tests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TESTID,EMPLOYEEID,HOURSTOCOMPLETE,BASEPRICE,NUMBEROFDAYS,TESTDESCRIPTION,PROGRESS,TESTCONDITIONAL")] Test test)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EMPLOYEEID = new SelectList(db.Employee, "EMPLOYEEID", "EMPFIRSTNAME", test.EMPLOYEEID);
            ViewBag.TESTCONDITIONAL = new SelectList(db.Test, "TESTID", "TESTDESCRIPTION", test.TESTCONDITIONAL);
            return View(test);
        }

        // GET: Tests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Test.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: Tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test test = db.Test.Find(id);
            db.Test.Remove(test);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
