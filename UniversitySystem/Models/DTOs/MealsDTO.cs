namespace UniversitySystem.Models.DTOs
{
    public class MealsDTO
    {
        public DateTime Date { get; set; }
        public int Type { get; set; }
        public List<Dish> Dishes { get; set; }
    }
}
