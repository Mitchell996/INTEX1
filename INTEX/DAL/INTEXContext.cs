using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using INTEX.Models;

namespace INTEX.DAL
{
    public class INTEXContext : DbContext
    {
        public INTEXContext() : base("INTEXContext")
          {
          }

        //Overlying fake tables for each table - data is initially committed to these tables, and then saved to the database.
        public DbSet<Assay> Assay { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Materials> Material { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderTest> OrderTest { get; set; }
        public DbSet<Sample> Sample { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<TestMaterials> TestMaterial { get; set; }
        public DbSet<TestMeasurement> TestMeasurement { get; set; }


    }
}