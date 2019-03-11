using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdracht_Webshop.Models
{
    public class Shoppingitem
    {
        public int ShoppingitemID { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public int ProductID { get; set; }
        public int ShoppingbagID { get; set; }

        public double BerekenSubTotaal()
        {
            return this.Quantity * this.Product.Price;
        }
    }
}
