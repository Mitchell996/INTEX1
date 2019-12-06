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
    public class OrdersController : Controller
    {
        private INTEXContext db = new INTEXContext();

        // GET: Orders
        public ActionResult Index()
        {
            var order = db.Order.Include(o => o.Customer);
            return View(order.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            TempData["ORDERID"] = id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("ViewOrderTests", "OrderTests");
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.CUSTOMERID = new SelectList(db.Customer, "CustomerID", "CustName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ORDERID,CUSTOMERID,ORDERCOMMENTS,ORDERPROGRESS")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Order.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CUSTOMERID = new SelectList(db.Customer, "CustomerID", "CustName", order.CUSTOMERID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CUSTOMERID = new SelectList(db.Customer, "CustomerID", "CustCity", order.CUSTOMERID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ORDERID,CUSTOMERID,ORDERCOMMENTS,ORDERPROGRESS")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CUSTOMERID = new SelectList(db.Customer, "CustomerID", "CustCity", order.CUSTOMERID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Order.Find(id);
            db.Order.Remove(order);
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
        public ActionResult AddTests(int? id)
        { int newid = (int)id;
            ViewBag.CurrentOrderID = newid;
            TempData["ORDERID"] = newid;
            // ViewBag.TESTID = new SelectList(db.Test, "TESTID", "TESTDESCRIPTION");
            //ViewBag.ORDERID = new SelectList(newid, "ORDERID", "ORDERCOMMENTS");
            return RedirectToAction( "AddToOrder", "OrderTests");
        }

    }
}
