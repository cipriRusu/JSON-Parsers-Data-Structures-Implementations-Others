using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Xunit;
using System.Linq;

namespace Functional_LINQ.TestResultsPicker
{
    public class TestResultsTest
    {
        [Fact]
        public void TestResultsReturnsOnlyResultPresentInList()
        {
            var testResultsPicker = new TestResultsPicker();

            var inputResults = new List<TestResults>()
            {
                new TestResults() { FamilyId = "A", Id = "FirstIdentifier", Score = 9 }
            };

            var expected = new List<TestResults>()
            {
                new TestResults() { FamilyId = "A", Id = "FirstIdentifier", Score = 9 }
            };

            Assert.Equal(expected, testResultsPicker.MaximumScorePicker(inputResults), new TestComparer());
        }

        [Fact]
        public void TestResultsReturnsGreatestElementInSetFromSingleSet()
        {
            var testResultsPicker = new TestResultsPicker();

            var inputResults = new List<TestResults>()
            {
                new TestResults() { FamilyId = "A", Id = "FirstIdentifier", Score = 9 },
                new TestResults() { FamilyId = "A", Id = "SecondIdentifier", Score = 15 }
            };

            var expected = new List<TestResults>()
            {
                new TestResults() { FamilyId = "A", Id = "SecondIdentifier", Score = 15 }
            };

            Assert.Equal(expected, testResultsPicker.MaximumScorePicker(inputResults), new TestComparer());
        }

        [Fact]
        public void TestResultsReturnsBothValuesForEqualValuesFromSingleSet()
        {
            var testResultsPicker = new TestResultsPicker();

            var inputResults = new List<TestResults>()
            {
                new TestResults() { FamilyId = "A", Id = "FirstIdentifier", Score = 3 },
                new TestResults() { FamilyId = "A", Id = "SecondIdentifer", Score = 3 }
            };

            var expected = new List<TestResults>()
            {
                 new TestResults() { FamilyId = "A", Id = "FirstIdentifier", Score = 3 },
                 new TestResults() { FamilyId = "A", Id = "SecondIdentifer", Score = 3 }
            };

            Assert.Equal(expected, testResultsPicker.MaximumScorePicker(inputResults), new TestComparer());
        }

        [Fact]
        public void TestResultsReturnsGreatestElementInSetsFromTwoSets()
        {
            var testResultsPicker = new TestResultsPicker();

            var inputResults = new List<TestResults>()
            {
                new TestResults() { FamilyId = "A", Id = "FirstIdentifier", Score = 9 },
                new TestResults() { FamilyId = "A", Id = "SecondIdentifier", Score = 15 },
                new TestResults() { FamilyId = "B", Id = "OtherIdentifier", Score = 3 },
                new TestResults() { FamilyId = "B", Id = "RandomIdentifier", Score = 12 }
            };

            var expected = new List<TestResults>()
            {
                new TestResults() { FamilyId = "A", Id = "SecondIdentifier", Score = 15 },
                new TestResults() { FamilyId = "B", Id = "RandomIdentifier", Score = 12 }
            };

            Assert.Equal(expected, testResultsPicker.MaximumScorePicker(inputResults), new TestComparer());
        }

        [Fact]
        public void TestResultsReturnsGreatestElementsInSetsFromTwoSetsWithSingleSet()
        {
            var testResultsPicker = new TestResultsPicker();

            var inputResults = new List<TestResults>()
            {
                new TestResults() { FamilyId = "A", Id = "FirstIdentifier", Score = 9 },
                new TestResults() { FamilyId = "A", Id = "SecondIdentifier", Score = 15 },
                new TestResults() { FamilyId = "B", Id = "OtherIdentifier", Score = 3 },
            };

            var expected = new List<TestResults>()
            {
                 new TestResults() { FamilyId = "B", Id = "OtherIdentifier", Score = 3 },
                 new TestResults() { FamilyId = "A", Id = "SecondIdentifier", Score = 15 }
            };

            Assert.Equal(expected, testResultsPicker.MaximumScorePicker(inputResults), new TestComparer());
        }

        [Fact]
        public void TestResultsReturnsGreatestElementsInMultipleThreeSetsWithMultipleElements()
        {
            var testResultsPicker = new TestResultsPicker();

            var inputResults = new List<TestResults>()
            {
                new TestResults() { FamilyId = "A", Id = "SecondIdentifier", Score = 15 },
                new TestResults() { FamilyId = "C", Id = "OtherRandomIdentifier", Score = 3 },
                new TestResults() { FamilyId = "B", Id = "OtherIdentifier", Score = 3 },
                new TestResults() { FamilyId = "B", Id = "RandomIdentifier", Score = 4 },
                new TestResults() { FamilyId = "C", Id = "LastIdentifier", Score = 2 },
                new TestResults() { FamilyId = "A", Id = "FirstIdentifier", Score = 9 }
            };

            var expected = new List<TestResults>()
            {
                new TestResults() { FamilyId = "A", Id = "SecondIdentifier", Score = 15 },
                new TestResults() { FamilyId = "B", Id = "RandomIdentifier", Score = 4 },
                new TestResults() { FamilyId = "C", Id = "OtherRandomIdentifier", Score = 3 }
            };

            Assert.Equal(expected, testResultsPicker.MaximumScorePicker(inputResults), new TestComparer());
        }
    }
}
