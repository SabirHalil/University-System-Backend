using System;
using System.Collections.Generic;

namespace UniversitySystem.Models
{
    public partial class Lecture
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public string? LectureName { get; set; }
        public string? LectureCode { get; set; }
        public int? LectureCredit { get; set; }
    }
}
