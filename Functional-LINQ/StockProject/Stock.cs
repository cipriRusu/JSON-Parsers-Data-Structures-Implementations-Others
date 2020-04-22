using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Functional_LINQ.StockProject
{
    public class Stock : IEnumerable
    {
        private List<Product> containedProducts = new List<Product>();

        public void Add(string productName, int productCount)
        {
            var current = containedProducts.Find(x => x.ProductName == productName);

            if (current == null)
            {
                containedProducts.Add(new Product(productName, productCount));
            }
            else
            {
                current.UpdateCounter(productCount);
            }
        }

        public int GetCounter(string productName)
        {
            var current = containedProducts.Find(x => x.ProductName == productName);

            if (current != null)
            {
                return current.ProductCount;
            }
            else
            {
                throw new ArgumentException("Product not found");
            }
        }

        public IEnumerator GetEnumerator()
        {
            if (containedProducts.Count == 0)
            {
                yield break;
            }

            foreach (var product in containedProducts)
            {
                yield return product;
            }
        }
    }
}
