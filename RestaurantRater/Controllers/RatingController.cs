using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantRater.Models;
using RestaurantRater.ViewModels;

namespace RestaurantRater.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public RatingController(RestaurantDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetRatings()
        {
            List<RatingListItem> ratingListItems = await _context.Ratings.Select(r =>
                        new RatingListItem
                        {
                            ID = r.ID,
                            RestaurantName = r.Restaurant!.Name,
                            FoodScore = r.FoodScore,
                            EnvironmentScore = r.EnvironmentScore,
                            CleanlinessScore = r.CleanlinessScore
                        }).ToListAsync();

            return Ok(ratingListItems);
        }

        [HttpPost]
        public async Task<IActionResult> AddRating(RatingCreate model)
        {
            if (ModelState.IsValid)
            {
                //manual mapping
                Rating rating = new Rating()
                {
                    RestaurantID = model.RestaurantID,
                    CleanlinessScore = model.CleanlinessScore,
                    EnvironmentScore = model.EnvironmentScore,
                    FoodScore = model.FoodScore
                };

                await _context.Ratings.AddAsync(rating);
                await _context.SaveChangesAsync();

                return Ok("Rating was successfully added.");
            }
            return BadRequest("Rating could not be added.");
        }

        [HttpPut]
        [Route("{ratingId:int}")]
        public async Task<IActionResult> UpdateRating(int ratingId, RatingEdit model)
        {
            if (ratingId == model.ID && ModelState.IsValid)
            {
                Rating ratingInDb = await _context
                                .Ratings
                                .Include(r => r.Restaurant)
                                .SingleOrDefaultAsync(x => x.ID == ratingId);

                if (ratingInDb is null)
                    return NotFound();
                else
                {
                    if (model.RestaurantID > 0)
                    {
                        ratingInDb.RestaurantID = model.RestaurantID;
                        ratingInDb.CleanlinessScore = model.CleanlinessScore;
                        ratingInDb.EnvironmentScore = model.EnvironmentScore;
                        ratingInDb.FoodScore = model.FoodScore;
                        await _context.SaveChangesAsync();
                        return Ok("Rating successfully update.");
                    }

                }
            }
            return BadRequest("Rating could not be updated.");
        }

        [HttpDelete]
        [Route("{ratingId:int}")]
        public async Task<IActionResult> DeleteRating(int ratingId)
        {
            if (ratingId > 0)
            {
                Rating ratingInDb = await _context
                                .Ratings
                                .Include(r => r.Restaurant)
                                .SingleOrDefaultAsync(x => x.ID == ratingId);

                if (ratingInDb is null)
                    return NotFound();
                else
                {
                    _context.Ratings.Remove(ratingInDb);
                    await _context.SaveChangesAsync();
                    return Ok("Rating successfully deleted.");
                }
            }
            return BadRequest("Rating could not be deleted.");
        }
    }
}