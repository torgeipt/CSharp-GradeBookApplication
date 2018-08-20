using GradeBook.Enums;
using System;
using System.Collections.Generic;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook {

        public RankedGradeBook(string name) :base(name) {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade) {
            int numStudents = Students.Count;

            if(numStudents < 5) {
                throw new InvalidOperationException();
            }

            // How many students to drop a grade(20%)
            int gradeDrop = Convert.ToInt32(numStudents * 0.2);

            // All average grades
            List<double> averageGrades = new List<double>(); 
            foreach(var student in Students) {
                averageGrades.Add(student.AverageGrade);
            }

            // Sort all average grades
            averageGrades.Sort();

            // Where the grade fits in the sorted grades
            int fit = 0;

            foreach(var grade in averageGrades) {
                if(averageGrade < grade) {
                    fit++;
                }
            }

            if (fit == 0)
                return 'A';
            else if (fit == 1)
                return 'B';
            else if (fit == 2)
                return 'C';
            else if (fit == 3)
                return 'D';
            else if (fit == 4)
                return 'E';

            return 'F';
        }
    }
}
