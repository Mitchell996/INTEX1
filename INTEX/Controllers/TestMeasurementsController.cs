using System;
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
    public class TestMeasurementsController : Controller
    {
        private INTEXContext db = new INTEXContext();

        // GET: TestMeasurements
        public ActionResult Index()
        {
            return View(db.TestMeasurement.ToList());
        }

        // GET: TestMeasurements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestMeasurement testMeasurement = db.TestMeasurement.Find(id);
            if (testMeasurement == null)
            {
                return HttpNotFound();
            }
            return View(testMeasurement);
        }

        // GET: TestMeasurements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestMeasurements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TESTMATERIALID,COMPOUNDLTID,COMPOUNDSEQCODE,CONCENTRATION,ASSAYID")] TestMeasurement testMeasurement)
        {
            if (ModelState.IsValid)
            {
                db.TestMeasurement.Add(testMeasurement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testMeasurement);
        }

        // GET: TestMeasurements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestMeasurement testMeasurement = db.TestMeasurement.Find(id);
            if (testMeasurement == null)
            {
                return HttpNotFound();
            }
            return View(testMeasurement);
        }

        // POST: TestMeasurements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TESTMATERIALID,COMPOUNDLTID,COMPOUNDSEQCODE,CONCENTRATION,ASSAYID")] TestMeasurement testMeasurement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testMeasurement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testMeasurement);
        }

        // GET: TestMeasurements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestMeasurement testMeasurement = db.TestMeasurement.Find(id);
            if (testMeasurement == null)
            {
                return HttpNotFound();
            }
            return View(testMeasurement);
        }

        // POST: TestMeasurements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestMeasurement testMeasurement = db.TestMeasurement.Find(id);
            db.TestMeasurement.Remove(testMeasurement);
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
