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
    public class AssaysController : Controller
    {
        private INTEXContext db = new INTEXContext();

        // GET: Assays
        public ActionResult Index()
        {
            var assay = db.Assay.Include(a => a.Test);
            return View(assay.ToList());
        }

        // GET: Assays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assay assay = db.Assay.Find(id);
            if (assay == null)
            {
                return HttpNotFound();
            }
            return View(assay);
        }

        // GET: Assays/Create
        public ActionResult Create()
        {
            ViewBag.TESTID = new SelectList(db.Test, "TESTID", "TESTDESCRIPTION");
            return View();
        }

        // POST: Assays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ASSAYID,RESULT,COMMENTS,TESTID")] Assay assay)
        {
            if (ModelState.IsValid)
            {
                db.Assay.Add(assay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TESTID = new SelectList(db.Test, "TESTID", "TESTDESCRIPTION", assay.TESTID);
            return View(assay);
        }

        // GET: Assays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assay assay = db.Assay.Find(id);
            if (assay == null)
            {
                return HttpNotFound();
            }
            ViewBag.TESTID = new SelectList(db.Test, "TESTID", "TESTDESCRIPTION", assay.TESTID);
            return View(assay);
        }

        // POST: Assays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ASSAYID,RESULT,COMMENTS,TESTID")] Assay assay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TESTID = new SelectList(db.Test, "TESTID", "TESTDESCRIPTION", assay.TESTID);
            return View(assay);
        }

        // GET: Assays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assay assay = db.Assay.Find(id);
            if (assay == null)
            {
                return HttpNotFound();
            }
            return View(assay);
        }

        // POST: Assays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assay assay = db.Assay.Find(id);
            db.Assay.Remove(assay);
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
