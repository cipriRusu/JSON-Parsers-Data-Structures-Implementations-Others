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
            var product = new Product();
            product.SetNameAndCount("Bere", 3);

            Assert.Equal("Bere", product.ProductName);
        }

        [Fact]
        public void CreatesProductclassAndPopulatesQuantity()
        {
            var product = new Product();
            product.SetNameAndCount("Bere", 4);

            Assert.Equal(4, product.ProductCount);
        }

        [Fact]
        public void CreatesProductClassThrowsArgumentExceptionForNullName()
        {
            var product = new Product();

            Assert.Throws<ArgumentNullException>(() => product.SetNameAndCount(null, 4));
        }

        [Fact]
        public void CreatesProductclassThrowsArgumentExceptionForNegativeQuantity()
        {
            var product = new Product();

            Assert.Throws<ArgumentException>(() => product.SetNameAndCount("Mici", -3));
        }

        [Fact]
        public void CreatesProductClassUpdatesCounterForNewUpdatedValue()
        {
            var product = new Product();

            product.SetNameAndCount("Bere", 3);
            product.UpdateCounter(9);

            Assert.Equal(12, product.ProductCount);
        }
    }
}
