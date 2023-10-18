using Microsoft.AspNetCore.Mvc;
using PokeDokeMartRedux.Models;
using PokeDokeMartRedux.Data;
using Microsoft.EntityFrameworkCore;

namespace PokeDokeMartRedux.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase
{
    private PokeDokeMartReduxDbContext _dbContext;
    public ReviewController(PokeDokeMartReduxDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetAllReviews(string userProfileId)
    {

        if (userProfileId == null)
        {
            //return all reviews
            return Ok(_dbContext.Reviews
            .Include(r => r.UserProfile)
            .Include(r => r.Item));        }
        else
        {
            int convUserProfileId = int.Parse(userProfileId);
            //if query param exists for userProfileId, only return reviews from that user
            UserProfile foundUserProfile = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == convUserProfileId);

            if (foundUserProfile == null)
            {
                return NotFound();
            }

            List<Review> foundReviews = _dbContext.Reviews
            .Include(r => r.UserProfile)
            .Include(r => r.Item)
            .Where(r => r.UserProfileId == convUserProfileId)
            .ToList();

            return Ok(foundReviews);
        }
    }

    [HttpGet("{id}")]
    // [Authorize]
    public IActionResult GetSingleReview(int id)
    {
        Review foundReview = _dbContext.Reviews
        .Include(r => r.Item)
        .Include(r => r.UserProfile)
        .ThenInclude(up => up.Orders)
        .ThenInclude(o => o.OrderItems)
        .ThenInclude(oi => oi.Item).SingleOrDefault(i => i.Id == id);

        if (foundReview == null)
        {
            return NotFound();
        }

        return Ok(foundReview);
    }
}