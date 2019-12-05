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
    public class EmployeesController : Controller
    {
        private INTEXContext db = new INTEXContext();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employee.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EMPLOYEEID,EMPFIRSTNAME,EMPLASTNAME,HOURLYWAGE")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EMPLOYEEID,EMPFIRSTNAME,EMPLASTNAME,HOURLYWAGE")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employee.Find(id);
            db.Employee.Remove(employee);
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

        public ActionResult CalculatePrices(int OrderNumber)
        {
            //Material quantity used, Material price
            var invoice =
                db.Database.SqlQuery<InvoicePrint>(
                    "Select Employee.EMPFIRSTNAME + ' ' + Employee.EMPLASTNAME AS 'EmployeeAssigned'" +
                        "Employee.HOURLYWAGE AS EmployeeWage, " +
                        //Test name, hours to complete, base price,
                        "Test.TESTDESCRIPTION AS TestName, " +
                        ".Test.HOURSTOCOMPLETE AS HoursRequired, " +
                        "Test.BASEPRICE AS BasePrice, " +

                        "TestMaterial.QUANTITYNEEDED AS MaterialQuantity , " +
                        "Material.COST AS MaterialPrice " +
                        "FROM Order, Employee, Test, TestMaterial, Material " +
                        "WHERE Order.EMPLOYEEID =Employee.EMPLOYEEID AND " +
                            "Test.ORDERID = Order.ORDERID AND" +
                            "TestMaterial.TESTID = Test.TESTID" +
                            "TestMaterial.MATERIALID = db.Material.MATERIALID AND" +
                            "Order.ORDERID == " + OrderNumber + ";");

            //if the invoice isn't already in the Invoice Database, add it.

           // if (db.Invoice.Find(invoice.InvoiceID) is null)



            return View(invoice);
            // List<T> FinalPrices = new List<T>;
            
                      
        }
    }

    
}
