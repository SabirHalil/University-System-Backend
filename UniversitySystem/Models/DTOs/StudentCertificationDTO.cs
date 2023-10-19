namespace UniversitySystem.Models.DTOs
{
    public class StudentCertificationDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DadName { get; set; }
        public string MomName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public int StudentNo { get; set; }
        public long IdCard { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string FacultyName { get; set; }
        public string CourseName { get; set; }
        public int Grade { get; set; }
    }
}
