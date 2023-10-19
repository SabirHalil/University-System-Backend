using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversitySystem.Models
{
    public partial class StudentLecture
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LectureId { get; set; }
        public int SemesterId { get; set; }
        public int TakenYear { get; set; }
        public int? Midterm { get; set; }
        public int? Final { get; set; }
        public int? Passed { get; set; }

    }
}
