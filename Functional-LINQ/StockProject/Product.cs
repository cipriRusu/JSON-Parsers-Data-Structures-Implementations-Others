using System;
using System.Collections.Generic;
using System.Text;

namespace Functional_LINQ.StockProject
{
    public class Product
    {
        public string ProductName { get; private set; }
        public int ProductCount { get; private set; }

        public void SetNameAndCount(string productName, int productCount)
        {
            NameAndCountExceptions(productName, productCount);

            ProductName = productName;
            ProductCount = productCount;
        }

        public void UpdateCounter(int newValue) => ProductCount += newValue;

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
