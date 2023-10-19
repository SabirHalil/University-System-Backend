using System.ComponentModel.DataAnnotations;

namespace UniversitySystem.Models.DTOs
{
    public class StudentLectureDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string LectureName { get; set; }
        public string LectureCode { get; set; }
        public int SemesterId { get; set; }
        public int TakenYear { get; set; }
        public int? Midterm { get; set; }
        public int? Final { get; set; }
        public int? Passed { get; set; }
    }
}
