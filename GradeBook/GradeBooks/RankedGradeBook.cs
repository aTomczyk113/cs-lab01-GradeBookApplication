using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook:BaseGradeBook
    {
        public RankedGradeBook(string name):base(name)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            int x = (int)Math.Ceiling(Students.Count * 0.20);
            int l = 0;

            for (int i = 0; i < Students.Count; i++)
            {
                double m = 0;
                for (int j = 0; j < Students[i].Grades.Count; j++)
                {
                    m = +Students[i].Grades[j];
                }
                if (averageGrade >= m / Students[i].Grades.Count)
                {
                    l++;
                }
            }
            if (l <= (int)Math.Ceiling(Students.Count * 0.20))
                return 'F';
            else if (l <= (int)Math.Ceiling(Students.Count * 0.40))
                return 'D';
            else if (l <= (int)Math.Ceiling(Students.Count * 0.60))
                return 'C';
            else if (l <= (int)Math.Ceiling(Students.Count * 0.80))
                return 'B';
            else
                return 'A';
        }
    }
}
