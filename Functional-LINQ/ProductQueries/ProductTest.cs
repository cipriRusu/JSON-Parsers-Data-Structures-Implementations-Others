using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Functional_LINQ.ProductQueries
{
    public class ProductTest
    {
        [Fact]
        public void ProductReturnsEmptyForProductsWithNoFeatureInList()
        {
            var testProducts = new List<Product>
            {
                new Product()
                {
                    Name = "FirstProd",
                    Features =
                    new List<Feature>()
                    {
                        new Feature(){Id = 3},
                        new Feature(){Id = 8},
                        new Feature(){Id = 2}
                    }
                },
                new Product()
                {
                    Name = "SecondProd",
                    Features =
                new List<Feature>()
                {
                    new Feature(){Id = 2},
                    new Feature(){Id = 4},
                    new Feature(){Id = 9}
                }
                }
            };

            var FeaturesList = new List<Feature>()
            {
                new Feature() {Id = 5},
                new Feature() {Id = 6},
                new Feature() {Id = 7}
            };

            Assert.Empty(new ProductFilter(testProducts)
                .ProductWithLeastOneFeature(FeaturesList));
        }

        [Fact]
        public void ProductReturnsProductWithLeastSingleFeaturePresentInList()
        {
            var testProducts = new List<Product>
            {
                new Product()
                {
                    Name = "FirstProd",
                    Features =
                    new List<Feature>()
                    {
                        new Feature(){Id = 3},
                        new Feature(){Id = 8},
                        new Feature(){Id = 2}
                    }
                },
                new Product()
                {
                    Name = "SecondProd",
                    Features =
                new List<Feature>()
                {
                    new Feature(){Id = 2},
                    new Feature(){Id = 4},
                    new Feature(){Id = 9}
                }
                }
            };

            var expected = new List<Product>
            {
                new Product()
                {
                    Name = "FirstProd",
                    Features =
                    new List<Feature>()
                    {
                        new Feature(){Id = 8},
                        new Feature(){Id = 3},
                        new Feature(){Id = 2}
                    }
                }
            };

            var FeaturesList = new List<Feature>()
            {
                new Feature() {Id = 1},
                new Feature() {Id = 3},
                new Feature() {Id = 5}
            };

            Assert.Equal(expected, new ProductFilter(testProducts)
                .ProductWithLeastOneFeature(FeaturesList));
        }

        [Fact]
        public void ProductReturnsValidProductsAndIgnoresProductWithNoFeatureInList()
        {
            var testProducts = new List<Product>
            {
                new Product()
                {
                    Name = "FirstProd",
                    Features =
                    new List<Feature>()
                    {
                        new Feature(){Id = 9},
                        new Feature(){Id = 8},
                        new Feature(){Id = 2}
                    }
                },
                new Product()
                {
                    Name = "SecondProd",
                    Features =
                new List<Feature>()
                {
                    new Feature(){Id = 10},
                    new Feature(){Id = 1},
                    new Feature(){Id = 5}
                }
                },
                new Product()
                {
                    Name = "ThirdProd",
                    Features =
                new List<Feature>()
                {
                    new Feature(){Id = 7},
                    new Feature(){Id = 8},
                    new Feature(){Id = 4}
                }
                }
            };

            var expected = new List<Product>();
            expected.Add(new Product()
            {
                Name = "FirstProd",
                Features =
                    new List<Feature>()
                    {
                        new Feature(){Id = 8},
                        new Feature(){Id = 3},
                        new Feature(){Id = 2}
                    }
            });
            expected.Add(new Product()
            {
                Name = "ThirdProd",
                Features =
                new List<Feature>()
                {
                    new Feature(){Id = 7},
                    new Feature(){Id = 8},
                    new Feature(){Id = 4}
                }
            });


            var FeaturesList = new List<Feature>()
            {
                new Feature() {Id = 8},
                new Feature() {Id = 3},
                new Feature() {Id = 0}
            };

            Assert.Equal(expected, new ProductFilter(testProducts)
                .ProductWithLeastOneFeature(FeaturesList));
        }

        [Fact]
        public void ProductWithAllFeaturesReturnsNoOutputForOneAvailableFeature()
        {
            var testProducts = new List<Product>
            {
                new Product()
                {
                    Name = "FirstProd",
                    Features =
                    new List<Feature>()
                    {
                        new Feature(){Id = 9},
                        new Feature(){Id = 8},
                        new Feature(){Id = 2}
                    }
                }
            };

            var FeaturesList = new List<Feature>()
            {
                new Feature() {Id = 8},
                new Feature() {Id = 3},
                new Feature() {Id = 0}
            };

            Assert.Empty(new ProductFilter(testProducts).ProductWithAllFeatures(FeaturesList));
        }

        [Fact]
        public void ProductWithAllFeaturesReturnsElementWithAllAvailableFeatures()
        {
            var testProducts = new List<Product>
            {
                new Product()
                {
                    Name = "ThirdProd",
                    Features =
                    new List<Feature>()
                    {
                        new Feature(){Id = 9},
                        new Feature(){Id = 8},
                        new Feature(){Id = 2}
                    }
                }
            };

            var expected = new List<Product>
            {
                new Product()
                {
                    Name = "ThirdProd",
                    Features =
                new List<Feature>()
                {
                    new Feature(){Id = 7},
                    new Feature(){Id = 8},
                    new Feature(){Id = 4}
                }
                }
            };

            var featuresList = new List<Feature>()
            {
                new Feature() {Id = 8},
                new Feature() {Id = 9},
                new Feature() {Id = 2}
            };

            Assert.Equal(expected, new ProductFilter(testProducts).ProductWithAllFeatures(featuresList));
        }
    }
}
