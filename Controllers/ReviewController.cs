using Microsoft.AspNetCore.Mvc;
using PokeDokeMartRedux.Models;
using PokeDokeMartRedux.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
            .Include(r => r.Item));
        }
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

    [HttpGet("item/{id}")]
    // [Authorize]
    public IActionResult GetAllReviewsForItem(int id)
    {
        Item foundItem = _dbContext.Items.SingleOrDefault(i => i.Id == id);

        if (foundItem == null)
        {
            return NotFound();
        }

        List<Review> reviewsForItem = _dbContext.Reviews
        .Include(r => r.UserProfile)
        .Include(r => r.Item)
        .Where(r => r.ItemId == id)
        .ToList();

        return Ok(reviewsForItem);
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

    [HttpPost]
    // [Authorize]
    public IActionResult CreateNewReview(Review incomingReview)
    {
        var loggedInUser = _dbContext
             .UserProfiles
             .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        Review newReview = new()
        {
            UserProfileId = loggedInUser.Id,
            ItemId = incomingReview.ItemId,
            Rating = incomingReview.Rating,
            Body = incomingReview.Body,
            Date = DateTime.Now
        };

        _dbContext.Reviews.Add(newReview);
        _dbContext.SaveChanges();

        return Created($"/api/review/{newReview.Id}", newReview);
    }

    [HttpPut]
    // [Authorize]
    public IActionResult UpdateReview(Review incomingReview)
    {
        Review foundReview = _dbContext.Reviews.SingleOrDefault(r => r.Id == incomingReview.Id);

        if (foundReview == null)
        {
            return NotFound();
        }

        foundReview.Rating = incomingReview.Rating;
        foundReview.Body = incomingReview.Body;

        _dbContext.SaveChanges();

        return NoContent();
    }
}