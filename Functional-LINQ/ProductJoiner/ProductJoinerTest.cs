using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Functional_LINQ.ProductJoiner
{
    public class ProductJoinerTest
    {
        [Fact]
        public void ProductJoinerCombinesTwoSingleCollections()
        {
            var firstList = new List<Product>()
            { new Product() { Name = "First", Quantity = 3 }};
            var secondList = new List<Product>()
            { new Product() {Name = "First", Quantity = 2}};

            var joinLists = new ProductJoiner();

            var expected = new List<Product>()
            {
                new Product() {Name = "First", Quantity = 5}
            };

            Assert.Equal(expected,
            joinLists.JoinProducts(firstList, secondList));
        }

        [Fact]
        public void ProductJoinerCombinesTwoCollectionsOneSingleOneMulti()
        {
            var firstList = new List<Product>()
            {
                new Product() { Name = "First", Quantity = 3 },
                new Product() { Name = "First", Quantity = 3 }
            };

            var secondList = new List<Product>()
            { new Product() {Name = "First", Quantity = 2}};

            var joinLists = new ProductJoiner();

            var expected = new List<Product>()
            {
                new Product() {Name = "First", Quantity = 8}
            };

            Assert.Equal(expected,
            joinLists.JoinProducts(firstList, secondList));
        }

        [Fact]
        public void ProductJoinerCombinesTwoCollectionsMultiToMulti()
        {
            var firstList = new List<Product>()
            {
                new Product() { Name = "First", Quantity = 3 },
                new Product() { Name = "Second", Quantity = 1 }
            };

            var secondList = new List<Product>()
            {
                new Product() {Name = "First", Quantity = 1},
                new Product() { Name = "Second", Quantity = 3 }
            };

            var joinLists = new ProductJoiner();

            var expected = new List<Product>()
            {
                new Product() {Name = "First", Quantity = 4},
                new Product() {Name = "Second", Quantity = 4}
            };

            Assert.Equal(expected,
            joinLists.JoinProducts(firstList, secondList));
        }

        [Fact]
        public void ProductJoinerCombinesTwoCollectionsMultiToMultiSecond()
        {
            var firstList = new List<Product>()
            {
                new Product() { Name = "First", Quantity = 3 },
                new Product() { Name = "First", Quantity = 5 },
                new Product() { Name = "Second", Quantity = 3 },
                new Product() { Name = "Third", Quantity = 1 }
            };

            var secondList = new List<Product>()
            {
                new Product() { Name = "Third", Quantity = 3 },
                new Product() {Name = "First", Quantity = 1},
                new Product() {Name = "First", Quantity = 8}
            };

            var joinLists = new ProductJoiner();

            var expected = new List<Product>()
            {
                new Product() {Name = "First", Quantity = 17},
                new Product() {Name = "Second", Quantity = 3},
                new Product() {Name = "Third", Quantity = 4}
            };

            Assert.Equal(expected,
            joinLists.JoinProducts(firstList, secondList));
        }

        [Fact]
        public void ProductJoinerCombinesTwoCollectionsMultiToMultiThird()
        {
            var firstList = new List<Product>()
            {
                new Product() { Name = "A", Quantity = 3 },
                new Product() { Name = "B", Quantity = 5 },
                new Product() { Name = "A", Quantity = 3 },
                new Product() { Name = "C", Quantity = 1 }
            };

            var secondList = new List<Product>()
            {
                new Product() { Name = "A", Quantity = 3 },
                new Product() {Name = "C", Quantity = 1},
                new Product() {Name = "B", Quantity = 8}
            };

            var joinLists = new ProductJoiner();

            var expected = new List<Product>()
            {
                new Product() {Name = "A", Quantity = 9},
                new Product() {Name = "B", Quantity = 13},
                new Product() {Name = "C", Quantity = 2}
            };

            Assert.Equal(expected,
            joinLists.JoinProducts(firstList, secondList));
        }
    }
}
