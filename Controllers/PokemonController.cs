using Microsoft.AspNetCore.Mvc;
using PokeDokeMartRedux.Models;
using PokeDokeMartRedux.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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

    // [HttpGet("{id}")]
    // // [Authorize]
    // public IActionResult GetSinglePokemon(int id)
    // {
    //     Pokemon foundPokemon = _dbContext.Pokemon
    //     .Include(p => p.PokemonLearnableMoves)
    //     .ThenInclude(plm => plm.Move)
    //     .ThenInclude(m => m.PokeType)
    //     .Include(p => p.PokemonLearnableMoves)
    //     .ThenInclude(plm => plm.Move)
    //     .ThenInclude(m => m.DamageClass)
    //     .Include(p => p.PokemonTypes)
    //     .ThenInclude(pt => pt.PokeType)
    //     .SingleOrDefault(o => o.Id == id);

    //     if (foundPokemon == null)
    //     {
    //         return NotFound();
    //     }

    //     return Ok(foundPokemon);
    // }


    [HttpGet("mypokemon")]
    // [Authorize]
    public IActionResult GetMyPokemon()
    {
        var loggedInUser = _dbContext
             .UserProfiles
             .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        List<UserPokemon> myPokemon = _dbContext.UserPokemon
        .Include(up => up.Pokemon)
        .Where(up => up.UserProfileId == loggedInUser.Id)
        .ToList();

        return Ok(myPokemon);

    }

    [HttpGet("mypokemon/{id}")]
    // [Authorize]
    public IActionResult GetSingleUserPokemon(int id)
    {
        UserPokemon foundUserPokemon = _dbContext.UserPokemon
        .Include(up => up.Pokemon)
        .ThenInclude(p => p.PokemonLearnableMoves)
        .ThenInclude(plm => plm.Move)
        .ThenInclude(m => m.PokeType)
        .Include(up => up.Pokemon)
        .ThenInclude(p => p.PokemonLearnableMoves)
        .ThenInclude(plm => plm.Move)
        .ThenInclude(m => m.DamageClass)
        .Include(up => up.Pokemon)
        .ThenInclude(p => p.PokemonTypes)
        .ThenInclude(p => p.PokeType)
        .SingleOrDefault(p => p.Id == id);

        if (foundUserPokemon == null)
        {
            return NotFound();
        }

        return Ok(foundUserPokemon);
    }
}