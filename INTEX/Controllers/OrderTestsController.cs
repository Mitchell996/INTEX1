using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using INTEX.DAL;
using INTEX.Models;

namespace INTEX.Controllers
{
    public class OrderTestsController : Controller
    {
        private INTEXContext db = new INTEXContext();

        // GET: OrderTests
        public ActionResult Index()
        {
            var orderTest = db.OrderTest.Include(o => o.Employee).Include(o => o.Order).Include(o => o.Test);
            return View(orderTest.ToList());
        }

        // GET: OrderTests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderTest orderTest = db.OrderTest.Find(id);
            if (orderTest == null)
            {
                return HttpNotFound();
            }
            return View(orderTest);
        }

        // GET: OrderTests/Create
        public ActionResult Create()
        {
            ViewBag.EMPLOYEEID = new SelectList(db.Employee, "EMPLOYEEID", "EMPFIRSTNAME");
            ViewBag.ORDERID = new SelectList(db.Order, "ORDERID", "ORDERCOMMENTS");
            ViewBag.TESTID = new SelectList(db.Test, "TESTID", "TESTDESCRIPTION");
            return View();
        }

        // POST: OrderTests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ORDERTESTID,EMPLOYEEID,TESTID,ORDERID")] OrderTest orderTest)
        {
            if (ModelState.IsValid)
            {
                db.OrderTest.Add(orderTest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EMPLOYEEID = new SelectList(db.Employee, "EMPLOYEEID", "EMPFIRSTNAME", orderTest.EMPLOYEEID);
            ViewBag.ORDERID = new SelectList(db.Order, "ORDERID", "ORDERCOMMENTS", orderTest.ORDERID);
            ViewBag.TESTID = new SelectList(db.Test, "TESTID", "TESTDESCRIPTION", orderTest.TESTID);
            return View(orderTest);
        }

        // GET: OrderTests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderTest orderTest = db.OrderTest.Find(id);
            if (orderTest == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMPLOYEEID = new SelectList(db.Employee, "EMPLOYEEID", "EMPFIRSTNAME", orderTest.EMPLOYEEID);
            ViewBag.ORDERID = new SelectList(db.Order, "ORDERID", "ORDERCOMMENTS", orderTest.ORDERID);
            ViewBag.TESTID = new SelectList(db.Test, "TESTID", "TESTDESCRIPTION", orderTest.TESTID);
            return View(orderTest);
        }

        // POST: OrderTests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ORDERTESTID,EMPLOYEEID,TESTID,ORDERID")] OrderTest orderTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderTest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EMPLOYEEID = new SelectList(db.Employee, "EMPLOYEEID", "EMPFIRSTNAME", orderTest.EMPLOYEEID);
            ViewBag.ORDERID = new SelectList(db.Order, "ORDERID", "ORDERCOMMENTS", orderTest.ORDERID);
            ViewBag.TESTID = new SelectList(db.Test, "TESTID", "TESTDESCRIPTION", orderTest.TESTID);
            return View(orderTest);
        }

        // GET: OrderTests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderTest orderTest = db.OrderTest.Find(id);
            if (orderTest == null)
            {
                return HttpNotFound();
            }
            return View(orderTest);
        }

        // POST: OrderTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderTest orderTest = db.OrderTest.Find(id);
            db.OrderTest.Remove(orderTest);
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

        public ActionResult AddToOrder()
        {
            ViewBag.CurrentOrderID = (int)TempData["ORDERID"];
            TempData["ORDER"] = TempData["ORDERID"];
            ViewBag.EMPLOYEEID = new SelectList(db.Employee, "EMPLOYEEID", "EMPFIRSTNAME");
            //ViewBag.ORDERID = new SelectList(db.Order, "ORDERID", "ORDERCOMMENTS");
            ViewBag.TESTID = new SelectList(db.Test, "TESTID", "TESTDESCRIPTION");
            return View();
        }
        [HttpPost]
        public ActionResult AddToOrder(int TestID)
        {
            int ORDERID = (int)TempData["ORDER"];

            OrderTest newOrder = new OrderTest(TestID, ORDERID);
            db.OrderTest.Add(newOrder);
            db.SaveChanges();

            return RedirectToAction("Index","Orders");
        }

        public ActionResult ViewOrderTests()
        {
            var orderTest = db.OrderTest.Include(o => o.Employee).Include(o => o.Order).Include(o => o.Test);


            /*DataTable dt = new DataTable();
            int rows_returned;

            const string credentials = @"Data Source=DESKTOP-7TA3SMB\SQLEXPRESS;Initial Catalog=INTEXContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            const string sqlQuery = @"
            SELECT ";

            using (SqlConnection connection = new SqlConnection(credentials))
            using (SqlCommand cmd = connection.CreateCommand())
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                cmd.CommandText = sqlQuery;
                cmd.CommandType = CommandType.Text;
                connection.Open();
                rows_returned = sda.Fill(dt);
                connection.Close();
            }

            if (dt.Rows.Count == 0)
            {
                // query returned no rows
            }
            else
            {

                //write semicolon-delimited header
                string[] columnNames = dt.Columns
                                         .Cast<DataColumn>()
                                         .Select(c => c.ColumnName)
                                         .ToArray()
                                         ;
                string header = string.Join(",", columnNames);
                Console.WriteLine(header);

                // write each row
                foreach (DataRow dr in dt.Rows)
                {

                    // get each rows columns as a string (casting null into the nil (empty) string
                    string[] values = new string[dt.Columns.Count];
                    for (int i = 0; i < dt.Columns.Count; ++i)
                    {
                        values[i] = ((string)dr[i]) ?? ""; // we'll treat nulls as the nil string for the nonce
                    }

                    // construct the string to be dumped, quoting each value and doubling any embedded quotes.
                    string data = string.Join(";", values.Select(s => "\"" + s.Replace("\"", "\"\"") + "\""));
                    Console.WriteLine(values);

                }

            }*/

            return View(orderTest.ToList());
        }
    }
}
