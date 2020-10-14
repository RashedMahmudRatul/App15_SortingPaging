using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App13_EFCoreDBFirst.Models
{
    public class StudentCourse
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int studentId { get; set; }
        public string ResultGradePoint { get; set; }
        public double ResultLetterGrade { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }

    }
}
