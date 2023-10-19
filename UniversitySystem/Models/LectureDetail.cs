using System;
using System.Collections.Generic;

namespace UniversitySystem.Models
{
    public partial class LectureDetail
    {
        public int Id { get; set; }
        public int? LecturerId { get; set; }
        public int? LectureHours { get; set; }
        public string? LecturePlace { get; set; }

    }
}
