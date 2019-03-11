using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdracht_Webshop.Data
{
    public class DBInitializer
    {
        public static void Initialize(WebshopContext context)
        {
            context.Database.EnsureCreated();
            //checken dat DB al bestaat
            if (context.Customers.Any())
            {
                return; //Table Customers bestaat
            }
            if (context.Products.Any())
            {
                return; //Table Products bestaat
            }
            if (context.Shoppingbags.Any())
            {
                return; //Table Shoppingbags bestaat
            }
            if (context.Shoppingitems.Any())
            {
                return; //Table Shoppingitems bestaat
            }
            context.Customers.AddRange(
                new Models.Customer { Name = "Admin", Firstname = "Admin" },
                new Models.Customer { Name="Princen", Firstname="Kevin"}
               );
            context.SaveChanges();

            context.Products.AddRange(new Models.Product { Name = "Nike Air", Price = 75.50 },
                new Models.Product { Name="Nike Shirt", Price=25.75});
            context.SaveChanges();

            context.Shoppingbags.AddRange(new Models.Shoppingbag { Date = DateTime.Now,CustomerID =1});
            context.SaveChanges();

            context.Shoppingitems.AddRange(new Models.Shoppingitem { Quantity = 1, ProductID = 1, ShoppingbagID=1});
            context.SaveChanges();          

        }

    }
}
