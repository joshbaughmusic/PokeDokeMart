using Microsoft.AspNetCore.Mvc;
using PokeDokeMartRedux.Models;
using PokeDokeMartRedux.Data;
using Microsoft.EntityFrameworkCore;

namespace PokeDokeMartRedux.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private PokeDokeMartReduxDbContext _dbContext;
    public OrderController(PokeDokeMartReduxDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetAllOrders(string userProfileId)
    {
        if (userProfileId == null)
        {
            //return all orders
            return Ok(_dbContext.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Item)
            .Include(o => o.UserProfile));
        }
        else
        {
            int convUserProfileId = int.Parse(userProfileId);
            //if query param exists for userProfileId, only return orders from that user
            UserProfile foundUserProfile = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == convUserProfileId);

            if (foundUserProfile == null)
            {
                return NotFound();
            }

            List<Order> foundOrders = _dbContext.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Item)
            .Include(o => o.UserProfile)
            .Where(o => o.UserProfileId == convUserProfileId)
            .ToList();

            return Ok(foundOrders);
        }
    }

    [HttpGet("{id}")]
    // [Authorize]
    public IActionResult GetSingleOrder(int id)
    {
        Order foundOrder = _dbContext.Orders
        .Include(o => o.OrderItems)
        .ThenInclude(oi => oi.Item)
        .Include(o => o.UserProfile).SingleOrDefault(o => o.Id == id);

        if (foundOrder == null)
        {
            return NotFound();
        }

        return Ok(foundOrder);
    }
}