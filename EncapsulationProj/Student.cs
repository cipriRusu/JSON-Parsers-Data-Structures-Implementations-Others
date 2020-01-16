using System;

namespace EncapsulationProj
{
    internal class Student
    {
        private readonly string studentName;
        private Subject[] studentSubjects = new Subject[0];

        public Student(string inputStudentName)
        {
            if (inputStudentName == null)
            {
                this.studentName = "No Student Name";
            }

            this.studentName = inputStudentName;
        }

        public Student(string inputStudentName,
            string inputSubjectName, int inputSubjectGrade)
        {
            this.studentName = inputStudentName;
            AddGrade(inputSubjectName, inputSubjectGrade);
        }

        private bool HasSubject(string inputSubjectName)
        {
            foreach (var t in studentSubjects)
            { if (t.IsEqual(inputSubjectName)) return true; }

            return false;
        }

        public void AddGrade(string subjectName, int subjectGrade)
        {
            if (!HasSubject(subjectName))
            {
                Array.Resize(ref studentSubjects, studentSubjects.Length + 1);
                studentSubjects[studentSubjects.Length - 1] = new Subject(subjectName, subjectGrade);
            }
            else
            { UpdateExistingSubjectWithGrade(subjectName, subjectGrade); }
        }

        public bool IsEqual(string inputName)
        { return studentName == inputName; }

        public decimal GetAverage()
        {
            var totalAverageOutput = 0M;
            foreach (var currentStudentSubject in studentSubjects)
            { totalAverageOutput += currentStudentSubject.GetAverage(); }

            if (totalAverageOutput == 0 || studentSubjects.Length == 0) return 0M; 

            return decimal.Round(totalAverageOutput / studentSubjects.Length, 1);
        }

        private void UpdateExistingSubjectWithGrade(string subjectName, int subjectGrade)
        {
            foreach (var existingSubject in studentSubjects)
            {
                if (existingSubject.IsEqual(subjectName))
                { existingSubject.AddGrade(subjectGrade); }
            }
        }
    }
}
