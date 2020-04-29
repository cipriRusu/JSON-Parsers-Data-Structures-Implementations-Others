using System;
using System.Collections;
using System.Collections.Generic;

namespace Functional_LINQ.StockProject
{
    public class Stock : IEnumerable
    {
        const int firstThreshold = 10;
        const int secondThreshold = 5;
        const int thirdThreshold = 2;

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
            => this.callback = callback;

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

                SetCallback(current, oldCounter, newCounter);

                current.RemoveItems(productCount);
            }
        }

        private void SetCallback(Product current, int oldCounter, int newCounter)
        {
            if (callback != null)
            {
                if ((newCounter < firstThreshold && oldCounter >= firstThreshold) ||
                    (newCounter < secondThreshold && oldCounter >= secondThreshold) ||
                    (newCounter < thirdThreshold && oldCounter >= thirdThreshold))
                {
                    callback(current, newCounter);
                }
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
