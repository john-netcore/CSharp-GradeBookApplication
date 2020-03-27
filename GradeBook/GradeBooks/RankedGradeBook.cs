using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            // Ranked-grading requires a minimum of 5 students to work.
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            // 20 % of the total students.
            int studentSpan = (int)(Students.Count * 0.2);

            var studentsOrderedByGrade = Students.OrderByDescending(s => s.AverageGrade).ToList();


            int gradeA = studentSpan - 1;
            int gradeB = studentSpan * 2 - 1;
            int gradeC = studentSpan * 3 - 1;
            int gradeD = studentSpan * 4 - 1;

            if (averageGrade >= studentsOrderedByGrade[gradeA].AverageGrade)
            {
                return 'A';
            }
            else if (averageGrade >= studentsOrderedByGrade[gradeB].AverageGrade)
            {
                return 'B';
            }
            else if (averageGrade >= studentsOrderedByGrade[gradeC].AverageGrade)
            {
                return 'C';
            }
            else if (averageGrade >= studentsOrderedByGrade[gradeD].AverageGrade)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                System.Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }
    }
}