using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T03_Products
{
    public class Product : IComparable<Product>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Suplier { get; set; }
        public decimal Price { get; set; }

        public int CompareTo(Product other)
        {
            return this.Id.CompareTo(other.Id);
        }
    }
}
