using System;
using System.Collections.Generic;
using System.Text;

namespace Functional_LINQ.StockProject
{
    public class Product
    {
        public Product(string productName, int productCount)
        {
            NameAndCountExceptions(productName, productCount);

            ProductName = productName;
            ProductCount = productCount;
        }

        public string ProductName { get; private set; }
        public int ProductCount { get; private set; }
        public void AddItems(int newValue) => ProductCount += newValue;

        public void RemoveItems(int productCount)
        {
            var result = ProductCount - productCount;

            if (result >= 0) { ProductCount = result; }
            else
            {
                throw new ArgumentException
                    ("Removal count exceeds number of existent products in stock");
            }
        }

        private static void NameAndCountExceptions
            (string productName, int productCount)
        {
            if (string.IsNullOrEmpty(productName))
            {
                throw new ArgumentNullException("Product name was not valid");
            }

            if (productCount < 0)
            {
                throw new ArgumentException("Product Count is less than 0");
            }
        }
    }
}
