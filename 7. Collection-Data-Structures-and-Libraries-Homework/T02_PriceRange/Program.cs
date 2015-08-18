using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace T02_PriceRange
{
    internal class Product : IComparable<Product>
    {
        public int Price { get; set; }
        public string Name { get; set; }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //var pricesAndProducts = new OrderedMultiDictionary<int, string>(false);
            var pricesAndProducts = new OrderedBag<Product>();

            // add price and products            
            int currentPrice = 0;
            string currentProd = "product";
            for (int i = 0; i < 500000; i++)
            {
                if ((i % 10000) == 0)
                {
                    currentPrice++;
                }

                //pricesAndProducts.Add(currentPrice, currentProd + i );
                pricesAndProducts.Add(new Product() { Price = currentPrice, Name = currentProd + i });
            }


            int startPrice = 0;
            int endPrice = 50;

            //var productsInRange = pricesAndProducts.Range(startPrice, true, endPrice, true).KeyValuePairs.Take(20);
            //foreach (var prod in productsInRange)
            //{
            //    Console.WriteLine("{0} -> {1}", prod.Key, prod.Value);
            //} 

            var productsInRange = pricesAndProducts.Range(new Product() { Price = startPrice }, true,
                new Product() { Price = endPrice }, true).Take(20);
            Console.WriteLine("Found pdcts:");
            foreach (var prod in productsInRange)
            {
                Console.WriteLine("{0} -> {1}", prod.Price, prod.Name);
            } 
        }
    }
}
