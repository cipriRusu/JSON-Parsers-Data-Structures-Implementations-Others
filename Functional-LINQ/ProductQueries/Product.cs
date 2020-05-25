using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Functional_LINQ.ProductQueries
{
    public class Product : IEquatable<Product>
    {
        public string Name { get; set; }
        public ICollection<Feature> Features { get; set; }

        public bool Equals([AllowNull] Product other) => Name == other.Name;
    }

    public class ProductFilter
    {
        private List<Product> _products;

        public ProductFilter(List<Product> products)
        {
            _products = products;
        }

        internal IEnumerable<Product> ProductWithLeastOneFeature(List<Feature> featuresList)
        {
            return _products.Where(x => x.Features.Any(y => featuresList.Contains(y)));
        }

        internal IEnumerable ProductWithAllFeatures(List<Feature> featuresList)
        {
            return _products.Where(x => x.Features.All(y => featuresList.Contains(y)));
        }
    }
}
