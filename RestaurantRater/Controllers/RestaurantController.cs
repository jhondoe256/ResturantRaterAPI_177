using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantRater.Models;
using RestaurantRater.ViewModels;

namespace RestaurantRater.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public RestaurantController(RestaurantDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetResturants()
        {
            List<Restaurant> restaurants = await _context.Restaurants.Include(r => r.Ratings).ToListAsync();

            //manual mapping -> from: List<Restaurant> , to: List<RestaurantListItem>
            List<RestaurantListItem> restaurantListItems = restaurants.Select(r => new RestaurantListItem
            {
                ID = r.ID,
                Name = r.Name,
                Rating = r.Rating
            }).ToList();

            return Ok(restaurantListItems);
        }

        [HttpGet]
        [Route("{restaurantId:int}")]
        // api/[controller]/id
        public async Task<IActionResult> GetRestaurantById(int restaurantId)
        {
            Restaurant restaurant = await
                             _context.
                            Restaurants.
                            Include(r => r.Ratings).
                            FirstOrDefaultAsync(r => r.ID == restaurantId);

            if (restaurant != null)
            {
                //manual mapping....again...
                RestaurantDetail restaurantDetail = new RestaurantDetail()
                {
                    ID = restaurant!.ID,
                    Name = restaurant.Name,
                    Address = restaurant.Address,
                    OverallScore = restaurant.Rating,
                    FoodRating = restaurant.FoodRating,
                    EnvironmentRating = restaurant.EnvironmentRating,
                    CleanlinessRating = restaurant.CleanlinessRating,
                    IsRecommended = restaurant.IsRecommended
                };

                return Ok(restaurantDetail);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddRestaurant([FromForm] RestaurantCreate model)
        {
            if (ModelState.IsValid)
            {
                //manual mapping....
                Restaurant restaurant = new Restaurant()
                {
                    Name = model.Name,
                    Address = model.Address
                };

                //add restaurant to database
                await _context.Restaurants.AddAsync(restaurant);
                await _context.SaveChangesAsync();

                return Ok("Restaurant " + restaurant.Name + " was successfully created!");
            }
            return BadRequest("Restaurant failed to be added to the database.");
        }

        [HttpPut]
        [Route("/updateRestaurant/{restaurantId:int}")]
        public async Task<IActionResult> UpdateRestaurant(int restaurantId, RestaurantEdit model)
        {
            if (restaurantId == model.ID && ModelState.IsValid)
            {
                //find the restaurant in the database...
                Restaurant restaurantInDb = await _context.Restaurants.FirstOrDefaultAsync(x => x.ID == restaurantId);

                if (restaurantInDb != null)
                {
                    //need to update the restaurantInDb's data manually...
                    restaurantInDb.Name = model.Name;
                    restaurantInDb.Address = model.Address;

                    await _context.SaveChangesAsync();
                    return Ok("Restaurant was successfully updted!");
                }
                return NotFound();
            }
            return BadRequest("Restaurant failed to be updated.");
        }

        [HttpDelete]
        [Route("{restaurantId:int}")]
        public async Task<IActionResult> DeleteRestaurant(int restaurantId)
        {
            if (restaurantId > 0)
            {
                //find the restaurant in the database...
                Restaurant restaurantInDb = await _context.Restaurants.FirstOrDefaultAsync(x => x.ID == restaurantId);

                if (restaurantInDb != null)
                {
                    _context.Restaurants.Remove(restaurantInDb);
                    await _context.SaveChangesAsync();
                    return Ok("Restaurant was successfully deleted!");
                }
                return NotFound();
            }
            return BadRequest("Restaurant failed to be deleted.");
        }
    }
}