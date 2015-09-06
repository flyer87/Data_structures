using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace T03_Products
{
    public class ProductCollections : IProductCollection
    {
        private Dictionary<string, Product> productsById = new Dictionary<string, Product>();
        private OrderedDictionary<decimal, SortedSet<Product>> productsByPrice =
            new OrderedDictionary<decimal, SortedSet<Product>>(); // f1
        private Dictionary<string, SortedSet<Product>> productsByTitle =
            new Dictionary<string, SortedSet<Product>>(); // f2
        private Dictionary<string, SortedSet<Product>> productsByTitleAndPrice =
            new Dictionary<string, SortedSet<Product>>(); // f3
        private Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>> productsByTitleAndPriceRange =
            new Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>>(); // f4
        private Dictionary<string, SortedSet<Product>> productsBySupplierAndPrice =
            new Dictionary<string, SortedSet<Product>>(); // f5
        private Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>> productsBySupplierAndPriceRange =
            new Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>>(); // f6

        //private Dictionary<string, OrderedMultiDictionary<decimal, Product>> productsBySupplierAndPriceRangeExt =
        //    new Dictionary<string, OrderedMultiDictionary<decimal, Product>>(); // f6

        public void AddProduct(string id, string title, string supplier, decimal price)
        {
            Product product = new Product() { Id = id, Title = title, Price = price, Suplier = supplier };
            if (productsById.ContainsKey(id))
            {
                this.RemoveProduct(id);
            }

            this.productsById.Add(id, product);
            this.productsByPrice.AppendValueToKey(price, product);
            this.productsByTitle.AppendValueToKey(title, product);
            string priceAndTitle = title + "!&^" + price;
            this.productsByTitleAndPrice.AppendValueToKey(priceAndTitle, product);
            this.productsByTitleAndPriceRange[title].AppendValueToKey(price, product);
        }

        public bool RemoveProduct(string id)
        {
            //bool result = this.productsById.Remove(id);
            Product product;
            this.productsById.TryGetValue(id, out product);
            if (product == null)
            {
                return false;
            }

            // Remove by product by Id
            this.productsById.Remove(id);
            this.productsByPrice[product.Price].Remove(product);
            this.productsBySupplierAndPrice[product.Suplier].Remove(product);
            this.productsBySupplierAndPriceRange[product.Suplier][product.Price].Remove(product);
            this.productsByTitle[product.Title].Remove(product);
            this.productsByTitleAndPrice[product.Title + "!&^" + product.Price].Remove(product);
            this.productsByTitleAndPriceRange[product.Title][product.Price].Remove(product);

            return true;
        }

        public int Count
        {
            get { return this.productsById.Count; }
        }

        public IEnumerable<Product> FindProduct(decimal startPrice, decimal endPrice)
        {
            var productsInRange = this.productsByPrice.Range(startPrice, true, endPrice, false);
            foreach (var productsByPrice in productsInRange)
            {
                foreach (var product in productsByPrice.Value)
                {
                    yield return product;
                }
            }
        }

        public IEnumerable<Product> FindProduct(string title)
        {
            //throw new NotImplementedException();
            return this.productsByTitle.GetValuesForKey(title);
        }

        public IEnumerable<Product> FindProduct(string title, decimal price)
        {
            //throw new NotImplementedException();
            string titleAndPrice = title + "!&^" + price;
            return this.productsByTitleAndPrice.GetValuesForKey(titleAndPrice);
        }

        public IEnumerable<Product> FindProduct(string title, decimal startPrice, decimal endPrice)
        {
            //throw new NotImplementedException();
            var productsInRange = this.productsByTitleAndPriceRange[title].Range(startPrice, true, endPrice, true);
            foreach (var productsByPrice in productsInRange)
            {
                foreach (var product in productsByPrice.Value)
                {
                    yield return product;
                }
            }
        }

        public IEnumerable<Product> FindProductExt(string supplier, decimal price)
        {
            //throw new NotImplementedException();
            string supplierAndPrice = supplier + "!&^" + price;
            return this.productsBySupplierAndPrice.GetValuesForKey(supplierAndPrice);
        }

        public IEnumerable<Product> FindProductExt(string supplier, decimal startPrice, decimal endPrice)
        {
            //throw new NotImplementedException();
            var productsInRange = this.productsBySupplierAndPriceRange[supplier].Range(startPrice, true, endPrice, true);
            foreach (var productsByPrice in productsInRange)
            {
                foreach (var product in productsByPrice.Value)
                {
                    yield return product;
                }
            }
        }
    }
}