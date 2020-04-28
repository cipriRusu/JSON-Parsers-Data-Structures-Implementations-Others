using System;
using System.Collections;
using System.Collections.Generic;

namespace Functional_LINQ.StockProject
{
    public class Stock : IEnumerable
    {
        private Action<Product, int> callback;
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
                current.AddItems(productCount);
            }
        }

        public void AddCallback(Action<Product, int> callback)
        {
            this.callback = callback;
        }

        public void Remove(string productName, int productCount)
        {
            var current = containedProducts.Find(x => x.ProductName == productName);

            if (current == null)
            {
                throw new ArgumentException("Product does not exist in stock");
            }
            else
            {
                var oldCounter = current.ProductCount;
                var newCounter = current.ProductCount - productCount;

                if(callback != null)
                {
                    if (newCounter < 10 && oldCounter >= 10)
                    {
                        callback(current, newCounter);
                    }
                    else if (newCounter < 5 && oldCounter >= 5)
                    {
                        callback(current, newCounter);
                    }
                    else if (newCounter < 2 && oldCounter >= 2)
                    {
                        callback(current, newCounter);
                    }
                }

                current.RemoveItems(productCount);
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
