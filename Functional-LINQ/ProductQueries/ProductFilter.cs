using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Functional_LINQ.ProductQueries
{
    public class ProductFilter
    {
        private List<Product> _products;

        public ProductFilter(List<Product> products) =>
            _products = products;

        internal IEnumerable<Product> ProductWithLeastOneFeature(List<Feature> featuresList) =>
            _products.Where(x => x.Features.Any(y => featuresList.Contains(y)));

        internal IEnumerable ProductWithAllFeatures(List<Feature> featuresList) =>
            _products.Where(x => featuresList.All(y => x.Features.Contains(y)));

        internal IEnumerable ProductWithNoFeatures(List<Feature> featuresList) =>
            _products.Where(x => featuresList.All(y => !x.Features.Contains(y)));
    }
}
