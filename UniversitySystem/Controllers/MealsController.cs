using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Models;
using UniversitySystem.Models.DTOs;

namespace UniversitySystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly UniversitySystemDbContext _context;
        public MealsController(UniversitySystemDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealsDTO>>> GetMeals()
        {
            DateTime today = DateTime.Today;
            DateTime tomorrow = today.AddDays(1);
            DateTime dayAfterTomorrow = today.AddDays(2);

            var meals = await _context.Meals
                .Where(m => m.Date >= today && m.Date <= dayAfterTomorrow)
                .ToListAsync();
            List<MealsDTO> result = new List<MealsDTO>();
            foreach(var meal in meals)
            {
                List<Dish> dishList = new List<Dish>();
                var dishesId = await _context.MealDishes.Where(m => m.MealId == meal.Id).Select(l => l.DishId).ToListAsync();
                foreach(var id in dishesId) {
                    var dish = await _context.Dishes.Where(m => m.Id == id).SingleOrDefaultAsync();
                    if(dish != null)
                    {
                        dishList.Add(dish);
                    }
                }
                MealsDTO mealsDTO = new MealsDTO
                {
                    Date = meal.Date,
                    Type = meal.Type,
                    Dishes = dishList
                };
                result.Add(mealsDTO);
            }

                return Ok(result);
        }
     
    }
}
