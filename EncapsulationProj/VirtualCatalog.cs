using System;

namespace EncapsulationProj
{
    internal class VirtualCatalog
    {
        private Student[] students;

        public VirtualCatalog() { students = new Student[0]; }

        public void AddGrade(string studentName, string subjectName, int grade)
        {
            if (IsInList(studentName))
            { UpdateExistingStudent(studentName, 
                subjectName, grade); }
            else
            { InsertNewStudent(studentName, 
                subjectName, grade); }
        }

        public Student StudentAtPosition(int position)
        { SortArray(0, students.Length - 1);
            return students[position]; }

        public int IndexOfName(string inputStringName)
        {
            int outValue = -1;
            SortArray(0, students.Length - 1);
            for (var i = 0; i < students.Length; i++)
            {
                if (!students[i].IsEqual(inputStringName)) continue;
                outValue = i;
                break;
            }

            return outValue;
        }

        private bool IsInList(string inputStudentName)
        {
            foreach (var presentStudent in students)
            { if (presentStudent.IsEqual(inputStudentName)) return true; }

            return false;
        }

        private void UpdateExistingStudent(string inputStudentName,
            string inputSubjectName, int inputSubjectGrade)
        {
            foreach (var existingStudents in students)
            {
                if (existingStudents.IsEqual(inputStudentName))
                {
                    existingStudents.AddGrade(inputSubjectName, 
                        inputSubjectGrade); }
            }
        }

        private void InsertNewStudent(string inputStudentName,
            string inputSubjectName, int inputSubjectGrade)
        {
            var newStudent = new Student(inputStudentName);
            Array.Resize(ref students, students.Length + 1);
            students[students.Length - 1] = newStudent;
            AddGrade(inputStudentName, inputSubjectName, inputSubjectGrade);
        }

        private void SortArray(int start, int end)
        {
            while (true)
            {
                if (start >= end) return;
                var i = PartitionArrayAtPivot(start, end);

                SortArray(start, i - 1);
                start = i + 1;
            }
        }

        private int PartitionArrayAtPivot(int start, int end)
        {
            Student temp;
            var p = students[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (students[j].GetAverage() < p.GetAverage()) continue;
                i++;
                temp = students[i];
                students[i] = students[j];
                students[j] = temp;
            }

            temp = students[i + 1];
            students[i + 1] = students[end];
            students[end] = temp;
            return i + 1;
        }
    }
}
