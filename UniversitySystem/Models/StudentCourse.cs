using System;
using System.Collections.Generic;

namespace UniversitySystem.Models
{
    public partial class StudentCourse
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int Grade { get; set; }
        public double? Gpa { get; set; }
    }
}
