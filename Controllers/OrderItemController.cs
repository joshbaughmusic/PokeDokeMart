using Microsoft.AspNetCore.Mvc;
using PokeDokeMartRedux.Models;
using PokeDokeMartRedux.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace PokeDokeMartRedux.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderItemController : ControllerBase
{
    private PokeDokeMartReduxDbContext _dbContext;
    public OrderItemController(PokeDokeMartReduxDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetAllOrderItems()
    {
        return Ok(_dbContext.OrderItems
        .Include(oi => oi.Order)
        .ThenInclude(o => o.UserProfile)
        .Include(oi => oi.Item)
        .ThenInclude(i => i.Category)
        .Include(oi => oi.Item)
        .ThenInclude(i => i.Move)
        .ThenInclude(m => m.PokeType));
    }
}