using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace Functional_LINQ.ProductQueries
{
    public class Product : IEquatable<Product>
    {
        public string Name { get; set; }
        public ICollection<Feature> Features { get; set; }
        public bool Equals([AllowNull] Product other) => 
            Name == other.Name && 
            other.Features.All(x => Features.Contains(x));
    }
}
