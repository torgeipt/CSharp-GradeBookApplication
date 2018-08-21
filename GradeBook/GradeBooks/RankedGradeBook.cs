using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook {

        public RankedGradeBook(string name, bool weighted) :base(name, weighted) {
            this.Type = GradeBookType.Ranked;
        }

        public override void CalculateStudentStatistics(string name) {

            if(Students.Count < 5) {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }

        public override void CalculateStatistics() {

            if(Students.Count < 5) {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override char GetLetterGrade(double averageGrade) {
            int numStudents = Students.Count;

            if (numStudents < 5) {
                throw new InvalidOperationException("Cannot be fewer than 5 students");
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

            return 'F';
        }
    }
}
