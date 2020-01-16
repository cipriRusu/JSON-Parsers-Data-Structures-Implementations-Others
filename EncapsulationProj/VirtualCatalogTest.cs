using System;
using Xunit;

namespace EncapsulationProj
{
    public class VirtualCatalogTest
    {
        [Fact]
        public void ShouldReturnStudentAtTheGivenPosition()
        {
            var catalog = new VirtualCatalog();
            catalog.AddGrade("FirstTestStudent", "Matematica", 9);
            var actual = catalog.StudentAtPosition(0);
            Assert.True(actual.IsEqual("FirstTestStudent"));
        }

        [Fact]
        public void AddGradeUpdateStudentIfAlreadyPresentInList()
        {
            var catalog = new VirtualCatalog();

            catalog.AddGrade("FirstStudent", "Math", 5);
            catalog.AddGrade("FirstStudent", "Biology", 4);

            var expectedValue = 4.5M;
            Assert.Equal(expectedValue, catalog.StudentAtPosition(0).GetAverage());
        }

        [Fact]
        public void AddGradeInsertsTwoEntriesForTwoDifferentNames()
        {
            var catalog = new VirtualCatalog();
            catalog.AddGrade("FirstStudent", "Math", 4);
            catalog.AddGrade("SecondStudent", "Biology", 5);

            var expectedValue = 5;
            Assert.Equal(expectedValue, catalog.StudentAtPosition(0).GetAverage());
        }

        [Fact]
        public void AddGradesUpdatesEntriesForMultipleInsertedGradesForSameSubject()
        {
            var catalog = new VirtualCatalog();
            catalog.AddGrade("FirstStudent", "Math", 4);
            catalog.AddGrade("SecondStudent", "Biology", 3);
            catalog.AddGrade("FirstStudent", "Math", 5);
            catalog.AddGrade("SecondStudent", "Biology", 6);

            var firstExpectedValue = 4.5M;
            var secondExpectedValue = 4.5M;

            Assert.Equal(firstExpectedValue, catalog.StudentAtPosition(0).GetAverage());
            Assert.Equal(secondExpectedValue, catalog.StudentAtPosition(1).GetAverage());
        }

        [Fact]
        public void StudentAtPositionReturnsTopStudentFromMultipleStudentsAndSigleSubjects()
        {
            var catalog = new VirtualCatalog();
            catalog.AddGrade("FirstStudent", "Math", 9);
            catalog.AddGrade("SecondStudent", "Biology", 2);
            catalog.AddGrade("ThirdStudent", "Physics", 10);

            Assert.True(catalog.StudentAtPosition(0).IsEqual("ThirdStudent"));
        }

        [Fact]
        public void StudentAtPositionReturnsThirdValueFromMultipleStudents()
        {
            var catalog = new VirtualCatalog();
            catalog.AddGrade("Gicu", "Matematica", 8);
            catalog.AddGrade("Dumitru", "Biologie", 4);
            catalog.AddGrade("Mihai", "Romana", 8);
            catalog.AddGrade("Ion", "Matematica", 3);
            catalog.AddGrade("Zenovia", "Chimie", 9);
            catalog.AddGrade("Gicu", "Biologie", 7);
            catalog.AddGrade("Mihai", "Chimie", 10);
            catalog.AddGrade("Gicu", "Matematica", 4);

            Assert.True(catalog.StudentAtPosition(2).IsEqual("Gicu"));
        }

        [Fact]
        public void IndexOfNameReturnsNullForNotExistentInput()
        {
            var catalog = new VirtualCatalog();
            var expectedValue = -1;
            Assert.Equal(expectedValue, catalog.IndexOfName(""));
        }

        [Fact]
        public void IndexOfNameReturnsFirstIndexFromSortedValues()
        {
            var catalog = new VirtualCatalog();
            catalog.AddGrade("FirstStudent", "Math", 4);
            catalog.AddGrade("SecondStudent", "Biologie", 10);
            catalog.AddGrade("ThirdStudent", "Chimie", 3);
            var expectedValue = 0;

            Assert.Equal(expectedValue, catalog.IndexOfName("SecondStudent"));
        }

        [Fact]
        public void IndexOfNameReturnsThirdIndexFromSortedValues()
        {
            var catalog = new VirtualCatalog();
            catalog.AddGrade("Gicu", "Matematica", 8);
            catalog.AddGrade("Dumitru", "Biologie", 4);
            catalog.AddGrade("Mihai", "Romana", 8);
            catalog.AddGrade("Ion", "Matematica", 3);
            catalog.AddGrade("Zenovia", "Chimie", 9);
            catalog.AddGrade("Gicu", "Biologie", 7);
            catalog.AddGrade("Mihai", "Chimie", 10);
            catalog.AddGrade("Gicu", "Matematica", 4);
            var expectedValue = 2;

            Assert.Equal(expectedValue, catalog.IndexOfName("Gicu"));
        }
    }
}
