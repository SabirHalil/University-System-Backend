namespace UniversitySystem.Models
{
    public class ChangePasswordBody
    {
        public int StudentId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }

}
