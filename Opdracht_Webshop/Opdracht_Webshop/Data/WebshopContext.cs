using Microsoft.EntityFrameworkCore;
using Opdracht_Webshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdracht_Webshop.Data
{
    public class WebshopContext: DbContext
    {
        public WebshopContext(DbContextOptions<WebshopContext> options) : base(options) { }

        public DbSet<Customer>Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shoppingbag> Shoppingbags { get; set; }
        public DbSet<Shoppingitem> Shoppingitems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Shoppingbag>().ToTable("Shoppingbag");
            modelBuilder.Entity<Shoppingitem>().ToTable("Shoppingitem");
        }

    }
}
