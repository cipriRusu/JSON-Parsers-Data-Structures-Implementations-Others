using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Functional_LINQ.ProductQueries
{
    public class Feature : IEquatable<Feature>
    {
        public int Id { get; set; }

        public bool Equals([AllowNull] Feature other)
        {
            return Id == other.Id;
        }
    }
}
