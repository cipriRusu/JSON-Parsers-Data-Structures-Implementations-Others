using System;
using Xunit;

namespace EncapsulationProj
{
    public class StudentTest
    {
        [Fact]
        public void IsEqualReturnsFalseForNullValueInName()
        {
            var testStudent = new Student(null);
            Assert.False(testStudent.IsEqual("Someone"));
        }

        [Fact]
        public void IsEqualReturnsTrueForValidValidInName()
        {
            var testStudent = new Student("Someone");
            Assert.True(testStudent.IsEqual("Someone"));
        }

        [Fact]
        public void GetAverageReturnsZeroForNoPresentSubjects()
        {
            var testStudent = new Student(null);
            var expectedValue = 0M;
            Assert.Equal(expectedValue, testStudent.GetAverage());
        }

        [Fact]
        public void GetAverageReturnsProperValueAverageForPresentSubject()
        {
            var testStudent = new Student(null);
            testStudent.AddGrade("Biologie", 9);
            var expectedValue = 9M;
            Assert.Equal(expectedValue, testStudent.GetAverage());
           
        }

        [Fact]
        public void GetAverageReturnsProperValueForStudentWithOneSubject()
        {
            var testStudent = new Student("Test Student");
            testStudent.AddGrade("Biologie", 4);
            testStudent.AddGrade("Biologie", 7);
            var expectedValue = 5.5M;

            Assert.Equal(expectedValue, testStudent.GetAverage());
        }

        [Fact]
        public void GetAverageReturnsProperValueForStudentWithMultipleGradeSingleSubjects()
        {
            var testStudent = new Student("Test Student");
            testStudent.AddGrade("Biologie", 7);
            testStudent.AddGrade("Matematica", 2);
            testStudent.AddGrade("Chimie", 4);
            var expectedValue = 4.3M;

            Assert.Equal(expectedValue, testStudent.GetAverage());
        }
    }
}
