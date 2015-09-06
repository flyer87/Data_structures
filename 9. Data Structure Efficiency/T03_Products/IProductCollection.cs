using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T03_Products
{
    interface IProductCollection
    {
        void AddProduct(string id, string title, string supplier, decimal price);
        bool RemoveProduct(string id);
        int Count { get; }

        IEnumerable<Product> FindProduct(decimal startPrice, decimal endPrice);
        IEnumerable<Product> FindProduct(string title);
        IEnumerable<Product> FindProduct(string title, decimal price);
        IEnumerable<Product> FindProduct(string title, decimal startPrice, decimal endPrice);
        IEnumerable<Product> FindProductExt(string supplier, decimal price);
        IEnumerable<Product> FindProductExt(string supplier, decimal startPrice, decimal endPrice);
    }
}
