using Microsoft.AspNetCore.Mvc;
using PokeDokeMartRedux.Models;
using PokeDokeMartRedux.Data;
using Microsoft.EntityFrameworkCore;

namespace PokeDokeMartRedux.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoveController : ControllerBase
{
    private PokeDokeMartReduxDbContext _dbContext;
    public MoveController(PokeDokeMartReduxDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetAllMoves()
    {
        return Ok(_dbContext.Moves
        .Include(m => m.PokeType)
        .Include(m => m.DamageClass));
    }

    [HttpGet("{id}")]
    // [Authorize]
    public IActionResult GetSingleMove(int id)
    {
        Move foundMove = _dbContext.Moves
        .Include(m => m.PokeType)
        .Include(m => m.DamageClass).SingleOrDefault(m => m.Id == id);

        if (foundMove == null)
        {
            return NotFound();
        }

        return Ok(foundMove);
    }
}