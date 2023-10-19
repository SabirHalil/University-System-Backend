using System;
using System.Collections.Generic;

namespace UniversitySystem.Models
{
    public partial class Course
    {

        public int Id { get; set; }
        public int FacultyId { get; set; }
        public string? CourseName { get; set; }
        public string? CourseCode { get; set; }

    }
}
