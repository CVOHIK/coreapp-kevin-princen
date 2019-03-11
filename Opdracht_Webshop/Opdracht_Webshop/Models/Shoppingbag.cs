using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Opdracht_Webshop.Models
{
    public class Shoppingbag
    {
        public int ShoppingbagID { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public List<Shoppingitem> Shoppingitems { get; set; }

        public double? TotalPrice { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public Boolean Closed { get; set; }

        public void BerekenTotalPrice()
        {
            double total = 0.00;
            if (Shoppingitems != null)
            {
                foreach (var item in Shoppingitems)
                {
                    total += item.Product.Price*item.Quantity;
                }
            }

            this.TotalPrice = total;
        }
    }
}
