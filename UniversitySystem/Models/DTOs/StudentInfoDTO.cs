using Microsoft.Build.Graph;

namespace UniversitySystem.Models.DTOs
{
    public class StudentInfoDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentNo { get; set; }
        public double Gpa { get; set; } = 0;
        public int Grade { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Iban { get; set; }

    }
}
