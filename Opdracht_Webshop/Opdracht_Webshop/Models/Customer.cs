using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdracht_Webshop.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public ICollection<Shoppingbag> Bags { get; set; }
        public string FullName { get { return Name + " " + Firstname; } }
    }
}
