using System;
using Xunit;

namespace EncapsulationProj
{
    public class SubjectTest
    {
        [Fact]
        public void IsSubjectReturnsTrueIfSubjectIsIdentical()
        {
            var testSub = new Subject("Matematica");
            var expectedSubjectName = "Matematica";

            Assert.True(testSub.IsEqual(expectedSubjectName));
        }

        [Fact]
        public void IsSubjectReturnFalseIfSubjectIsNotIdentical()
        {
            var testSub = new Subject("Matematica");
            var expectedSubjectName = "Biologie";

            Assert.False(testSub.IsEqual(expectedSubjectName));
        }

        [Fact]
        public void ReturnSubjectMeanReturnsZeroForNoValueInSubject()
        {
            var testSub = new Subject("Test Subject Name");
            var expectedMeanValue = 0M;

            Assert.Equal(expectedMeanValue, testSub.GetAverage());
        }

        [Fact]
        public void ReturnSubjectMeanReturnsProperValue()
        {
            var testSubject = new Subject("Math", 4);
            testSubject.AddGrade(7);
            testSubject.AddGrade(3);
            var expectedMeanValue = 4.7M;

            Assert.Equal(expectedMeanValue, testSubject.GetAverage());
        }

        [Fact]
        public void ReturnSubjectMeanReturnsZeroForZeroValue()
        {
            var testSubject = new Subject("Something");
            testSubject.AddGrade(0);
            var expectedMeanValue = 0M;

            Assert.Equal(expectedMeanValue, testSubject.GetAverage());
        }
    }
}
