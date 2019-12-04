using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using INTEX.DAL;
using INTEX.Models;
using Microsoft.VisualBasic.FileIO;

namespace INTEX.Controllers
{
    public class SamplesController : Controller
    {
        private INTEXContext db = new INTEXContext();

        // GET: Samples
        public ActionResult Index()
        {
            var sample = db.Sample.Include(s => s.Employee).Include(s => s.Order);
            return View(sample.ToList());
        }

        // GET: Samples/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sample sample = db.Sample.Find(id);
            if (sample == null)
            {
                return HttpNotFound();
            }
            return View(sample);
        }

        // GET: Samples/Create
        public ActionResult Create()
        {
            ViewBag.RECEIVEDBY = new SelectList(db.Employee, "EMPLOYEEID", "EMPFIRSTNAME");
            ViewBag.ORDERID = new SelectList(db.Order, "ORDERID", "ORDERCOMMENTS");
            return View();
        }

        // POST: Samples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COMPOUNDLTID,COMPOUNDSEQCODE,ORDERID,RECEIVEDBY,COMPOUNDNAME,QUANTITY,DATEARRIVED,DUEDATE,APPEARANCE,CLIENTWEIGHT,MOLARMASS,ACTUALWEIGHT,MTD")] Sample sample)
        {
            if (ModelState.IsValid)
            {
                db.Sample.Add(sample);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RECEIVEDBY = new SelectList(db.Employee, "EMPLOYEEID", "EMPFIRSTNAME", sample.RECEIVEDBY);
            ViewBag.ORDERID = new SelectList(db.Order, "ORDERID", "ORDERCOMMENTS", sample.ORDERID);
            return View(sample);
        }

        // GET: Samples/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sample sample = db.Sample.Find(id);
            if (sample == null)
            {
                return HttpNotFound();
            }
            ViewBag.RECEIVEDBY = new SelectList(db.Employee, "EMPLOYEEID", "EMPFIRSTNAME", sample.RECEIVEDBY);
            ViewBag.ORDERID = new SelectList(db.Order, "ORDERID", "ORDERCOMMENTS", sample.ORDERID);
            return View(sample);
        }

        // POST: Samples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COMPOUNDLTID,COMPOUNDSEQCODE,ORDERID,RECEIVEDBY,COMPOUNDNAME,QUANTITY,DATEARRIVED,DUEDATE,APPEARANCE,CLIENTWEIGHT,MOLARMASS,ACTUALWEIGHT,MTD")] Sample sample)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sample).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RECEIVEDBY = new SelectList(db.Employee, "EMPLOYEEID", "EMPFIRSTNAME", sample.RECEIVEDBY);
            ViewBag.ORDERID = new SelectList(db.Order, "ORDERID", "ORDERCOMMENTS", sample.ORDERID);
            return View(sample);
        }

        // GET: Samples/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sample sample = db.Sample.Find(id);
            if (sample == null)
            {
                return HttpNotFound();
            }
            return View(sample);
        }

        // POST: Samples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sample sample = db.Sample.Find(id);
            db.Sample.Remove(sample);
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

        public ActionResult ImportFromCSV()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImportFromCSV(HttpPostedFileBase file)
        {
            DataTable DataFromCSV = GetDataTabletFromCSVFile(file);
            InsertDataIntoSQLServer(DataFromCSV);
            if (Request.IsAjaxRequest())
            {
                return Json(new { status = "success" });
            }

            return View("Index");

        }

        public DataTable GetDataFromxlsx(HttpPostedFileBase file)
        {
            string filePath = string.Empty;
            if (file != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                file.SaveAs(filePath);

                string conString = string.Empty;

                switch (extension)
                {
                    case ".xls": //Excel 97-03.
                        conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES'";
                        break;
                    case ".xlsx": //Excel 07 and above.
                        conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES'";
                        break;
                }

                DataTable dt = new DataTable();
                conString = string.Format(conString, filePath);

                using (OleDbConnection connExcel = new OleDbConnection(conString))
                {
                    using (OleDbCommand cmdExcel = new OleDbCommand())
                    {
                        using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                        {
                            cmdExcel.Connection = connExcel;

                            //Get the name of First Sheet.
                            connExcel.Open();
                            DataTable dtExcelSchema;
                            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                            connExcel.Close();

                            //Read Data from First Sheet.
                            connExcel.Open();
                            cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                            odaExcel.SelectCommand = cmdExcel;
                            odaExcel.Fill(dt);
                            connExcel.Close();

                            return dt;
                        }
                    }
                }
            }
            return null;
        }

        private DataTable GetDataTabletFromCSVFile(HttpPostedFileBase file)
        {

            string csv_file_path = string.Empty;
            string filePath = string.Empty;
            if (file != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                file.SaveAs(filePath);
                csv_file_path = filePath;
            }
            else
            {
                return null;
            }

            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return csvData;
        }

        private void InsertDataIntoSQLServer(DataTable csvFileData)
        {
            IList<Sample> items = csvFileData.AsEnumerable().Select(row =>
            new Sample
            {
                COMPOUNDLTID = row.Field<string>("COMPOUNDLTID"),
                COMPOUNDSEQCODE = row.Field<int>("COMPOUNDSEQCODE"),
                ORDERID = row.Field<int>("ORDERID"),
                RECEIVEDBY = row.Field<int>("RECEIVEDBY"),
                COMPOUNDNAME = row.Field<string>("COMPOUNDNAME"),
                QUANTITY = row.Field<decimal>("QUANTITY"),
                DATEARRIVED = row.Field<DateTime>("DATEARRIVED"),
                DUEDATE = row.Field<DateTime>("DUEDATE"),
                APPEARANCE = row.Field<string>("APPEARANCE"),
                CLIENTWEIGHT = row.Field<decimal>("CLIENTWEIGHT"),
                MOLARMASS = row.Field<decimal>("MOLARMASS"),
                ACTUALWEIGHT = row.Field<decimal>("ACTUALWEIGHT"),
                MTD = row.Field<decimal>("MTD"),
            }).ToList();

            foreach (var item in items)
            {
                db.Sample.Add(item);
            }
            db.SaveChanges();

        }

    }
}
