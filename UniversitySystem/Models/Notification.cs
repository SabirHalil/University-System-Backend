namespace UniversitySystem.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime date { get; set; }
    }
}
