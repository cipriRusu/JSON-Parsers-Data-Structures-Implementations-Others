using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Functional_LINQ
{
    public class TestObject
    {
        public int FirstProperty;
        public string SecondProperty;
        public int ThirdProperty;
    }

    public class TestObjectComparer : IEqualityComparer<TestObject>
    {
        public bool Equals([AllowNull] TestObject x, [AllowNull] TestObject y)
        {
            return x.FirstProperty.Equals(y.FirstProperty) &&
                x.SecondProperty.Equals(y.SecondProperty) &&
                x.ThirdProperty.Equals(y.ThirdProperty);
        }

        public int GetHashCode([DisallowNull] TestObject obj)
        {
            return GetHashCode();
        }
    }
}
