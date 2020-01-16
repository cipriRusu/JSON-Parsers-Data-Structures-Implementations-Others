using System;
using System.Runtime.CompilerServices;

namespace EncapsulationProj
{
    internal class Subject
    {
        private readonly string subjectName;
        private int[] subjectGrades = new int[0];

        public Subject(string inputSubjectName)
        {
            this.subjectName = SetSubjectName(inputSubjectName);
        }

        public Subject(string inputSubjectName, int inputSubjectGrade)
        {
            this.subjectName = SetSubjectName(inputSubjectName);

            Array.Resize(ref subjectGrades, subjectGrades.Length + 1);
            subjectGrades[subjectGrades.Length - 1] = inputSubjectGrade;
        }

        public bool IsEqual(string inputSubjectName)
        { return subjectName == inputSubjectName; }

        public void AddGrade(int NewSubjectGradeValue)
        {
            Array.Resize(ref subjectGrades, subjectGrades.Length + 1);
            subjectGrades[subjectGrades.Length - 1] = NewSubjectGradeValue;
        }

        public decimal GetAverage()
        {
            var outputMeanValue = 0M;

            foreach (var t in subjectGrades)
            { outputMeanValue += t; }

            if (outputMeanValue == 0 || subjectGrades.Length == 0) return 0M;

            return decimal.Round(outputMeanValue / subjectGrades.Length, 
                1);
        }

        private string SetSubjectName(string inputSubjectName)
        {
            return string.IsNullOrEmpty(inputSubjectName) ? "No Subject" : inputSubjectName;
        }
    }
}
