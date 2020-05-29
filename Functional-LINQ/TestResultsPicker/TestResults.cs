using System;
using System.Diagnostics.CodeAnalysis;

namespace Functional_LINQ.TestResultsPicker
{
    public class TestResults : IComparable<TestResults>, IEquatable<TestResults>
    {
        public string Id { get; set; }
        public string FamilyId { get; set; }
        public int Score { get; set; }

        public int CompareTo(TestResults input) => 
            Score.CompareTo(input.Score);

        public bool Equals([AllowNull] TestResults other) => 
            Id == other.Id &&
            FamilyId == other.FamilyId &&
            Score == other.Score;
    }
}