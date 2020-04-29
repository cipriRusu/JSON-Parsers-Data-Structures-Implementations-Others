using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Functional_LINQ.StockProject
{
    public class StockTest
    {
        [Fact]
        public void CreatesProductClassAndPopulatesName()
        {
            var product = new Product("Bere", 3);

            Assert.Equal("Bere", product.ProductName);
        }

        [Fact]
        public void CreatesProductclassAndPopulatesQuantity()
        {
            var product = new Product("Bere", 4);

            Assert.Equal(4, product.ProductCount);
        }

        [Fact]
        public void CreatesProductClassThrowsArgumentExceptionForNullName()
        {
            Assert.Throws<ArgumentNullException>(() => new Product(null, 4));
        }

        [Fact]
        public void CreatesProductclassThrowsArgumentExceptionForNegativeQuantity()
        {
            Assert.Throws<ArgumentException>(() => new Product("Mici", -3));
        }

        [Fact]
        public void CreatesProductClassUpdatesCounterForNewUpdatedValue()
        {
            var product = new Product("Bere", 3);

            product.AddItems(9);

            Assert.Equal(12, product.ProductCount);
        }

        [Fact]
        public void StockCreatesEmptyStockClass()
        {
            var currentStock = new Stock();

            Assert.Empty(currentStock);
        }

        [Fact]
        public void StockPopulatesWithSingleProduct()
        {
            var currentStock = new Stock();

            currentStock.Add("Bere", 4);

            Assert.Single(currentStock);
        }

        [Fact]
        public void StockUpdatesCounterForSameProductAdd()
        {
            var currentStock = new Stock();

            currentStock.Add("Bere", 9);
            currentStock.Add("Bere", 1);

            Assert.Equal(10, currentStock.GetCounter("Bere"));
        }

        [Fact]
        public void StockUpdatesDifferentCountersForDifferentProductsAddition()
        {
            var currentStock = new Stock();

            currentStock.Add("Bere", 21);
            currentStock.Add("Mici", 4);

            currentStock.Add("Mici", 6);
            currentStock.Add("Bere", 10);

            Assert.Equal(31, currentStock.GetCounter("Bere"));
            Assert.Equal(10, currentStock.GetCounter("Mici"));
        }

        [Fact]
        public void StockUpdatesCounterForSameProductRemove()
        {
            var currentStock = new Stock();
            currentStock.Add("Banane", 2);
            currentStock.Add("Portocale", 8);

            currentStock.Remove("Portocale", 6);

            Assert.Equal(2, currentStock.GetCounter("Portocale"));
        }

        [Fact]
        public void StockThrowsArgumentExceptionIfProductRemovalExceedsNumberOfProducts()
        {
            var currentStock = new Stock();
            currentStock.Add("Banane", 2);
            currentStock.Add("Portocale", 8);

            Assert.Throws<ArgumentException>(() => currentStock.Remove("Portocale", 10));
        }

        [Fact]
        public void StockThrowsArgumentNullExceptionForAbsentProduct()
        {
            var currentStock = new Stock();
            currentStock.Add("Chips", 7);

            Assert.Throws<ArgumentException>(() => currentStock.GetCounter("Bere"));
        }

        [Fact]
        public void StockActionNotInvokedAndReturnsNullForNoCallback()
        {
            var currentStock = new Stock();
            Product testProduct = null;
            var testCounter = 0;

            void GetData(Product product, int counter)
            {
                testProduct = product;
                testCounter = counter;
            }

            currentStock.AddCallback(GetData);

            Assert.Null(testProduct);
        }

        [Fact]
        public void StockActionInvokedForLessThanTenElementsOfProduct()
        {
            var currentStock = new Stock();
            Product testProduct = null;
            var testCounter = 0;

            void GetData(Product product, int counter)
            {
                testProduct = product;
                testCounter = counter;
            }

            currentStock.AddCallback(GetData);
            currentStock.Add("Chips", 10);
            currentStock.Remove("Chips", 2);

            
            Assert.Equal("Chips", testProduct.ProductName);
            Assert.Equal(8, testProduct.ProductCount);
        }

        [Fact]
        public void StockActionInvokedForLessThanFiveElementsOfProduct()
        {
            var currentStock = new Stock();
            Product testProduct = null;
            var testCounter = 0;

            void GetData(Product product, int counter)
            {
                testProduct = product;
                testCounter = counter;
            }

            currentStock.AddCallback(GetData);
            currentStock.Add("Chips", 5);
            currentStock.Remove("Chips", 1);


            Assert.Equal("Chips", testProduct.ProductName);
        }

        [Fact]
        public void StockActionInvokedForLessThanTwoProductsOfProduct()
        {
            var currentStock = new Stock();
            Product testProduct = null;
            var testCounter = 0;

            void GetData(Product product, int counter)
            {
                testProduct = product;
                testCounter = counter;
            }

            currentStock.AddCallback(GetData);
            currentStock.Add("Chips", 2);
            currentStock.Remove("Chips", 1);


            Assert.Equal("Chips", testProduct.ProductName);
        }
        
        [Fact]
        public void StockActionInvokedOnlyOnceForConsecutivePurchases()
        {
            var currentStock = new Stock();
            Product testProduct = null;
            var testCounter = 0;

            void GetData(Product product, int counter)
            {
                testProduct = product;
                testCounter = counter;
            }

            currentStock.AddCallback(GetData);
            currentStock.Add("Beer", 10);
            currentStock.Remove("Beer", 1);
            currentStock.Remove("Beer", 1);

            Assert.Equal("Beer", testProduct.ProductName);
            Assert.Equal(9, testCounter);
        }

        [Fact]
        public void StockActionUpdatesIfProductCountIsIncreased()
        {
            var currentStock = new Stock();
            Product testProduct = null;
            var testCounter = 0;

            void GetData(Product product, int counter)
            {
                testProduct = product;
                testCounter = counter;
            }

            currentStock.AddCallback(GetData);
            currentStock.Add("Beer", 10);
            currentStock.Remove("Beer", 2);
            currentStock.Remove("Beer", 4);
            currentStock.Add("Beer", 15);
            currentStock.Remove("Beer", 10);

            Assert.Equal("Beer", testProduct.ProductName);
            Assert.Equal(9, testCounter);
        }
    }
}
