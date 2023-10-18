using Microsoft.AspNetCore.Mvc;
using PokeDokeMartRedux.Models;
using PokeDokeMartRedux.Data;
using Microsoft.EntityFrameworkCore;

namespace PokeDokeMartRedux.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PokemonController : ControllerBase
{
    private PokeDokeMartReduxDbContext _dbContext;
    public PokemonController(PokeDokeMartReduxDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetAllPokemon()
    {
            return Ok(_dbContext.Pokemon);
    }

    [HttpGet("{id}")]
    // [Authorize]
    public IActionResult GetSinglePokemon(int id)
    {
        Pokemon foundPokemon = _dbContext.Pokemon
        .Include(p => p.PokemonLearnableMoves)
        .ThenInclude(plm => plm.Move)
        .ThenInclude(m => m.PokeType)
        .Include(p => p.PokemonLearnableMoves)
        .ThenInclude(plm => plm.Move)
        .ThenInclude(m => m.DamageClass)
        .Include(p => p.PokemonTypes)
        .ThenInclude(pt => pt.PokeType)
        .SingleOrDefault(o => o.Id == id);

        if (foundPokemon == null)
        {
            return NotFound();
        }

        return Ok(foundPokemon);
    }
}