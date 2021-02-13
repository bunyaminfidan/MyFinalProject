using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntittFramework
{
    //Context: nesnesi Db tabloları ile proje classlarını baglamak
    public class NorthwindContext : DbContext
    {
        //Hangi veritabanı ile çalıştığımızı gösterdiğimiz yer.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Costumer> Costumers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
