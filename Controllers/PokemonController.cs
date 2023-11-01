using Microsoft.AspNetCore.Mvc;
using PokeDokeMartRedux.Models;
using PokeDokeMartRedux.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

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
    [Authorize]
    public IActionResult GetAllPokemon()
    {
        return Ok(_dbContext.Pokemon);
    }


    [HttpGet("mypokemon")]
    [Authorize]
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
    [Authorize]
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

    [HttpPost]
    [Authorize]
    public IActionResult CreateNewUserPokemon(UserPokemon incomingUserPokemon)
    {

        var loggedInUser = _dbContext
             .UserProfiles
             .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        List<UserPokemon> currentUserPokemon = _dbContext.UserPokemon.Where(up => up.UserProfileId == loggedInUser.Id).ToList();

        if (incomingUserPokemon.Level > 0 && incomingUserPokemon.Level <= 100 && currentUserPokemon.Count <= 6)
        {
            UserPokemon newUserPokemon = new()
            {
                NickName = incomingUserPokemon.NickName,
                UserProfileId = loggedInUser.Id,
                PokemonId = incomingUserPokemon.PokemonId,
                Level = incomingUserPokemon.Level
            };

            _dbContext.UserPokemon.Add(newUserPokemon);
            _dbContext.SaveChanges();

            return Created($"/api/pokemon/{newUserPokemon.Id}", newUserPokemon);
        }
        else
        {
            return BadRequest();
        }

    }

    [HttpPut]
    [Authorize]
    public IActionResult UpdateUserPokemon(UserPokemon incomingUserPokemon)
    {
        UserPokemon foundUserPokemon = _dbContext.UserPokemon.SingleOrDefault(up => up.Id == incomingUserPokemon.Id);

        if (foundUserPokemon == null)
        {
            return NotFound();
        }

        if (incomingUserPokemon.Level > 0 && incomingUserPokemon.Level <= 100)
        {

            foundUserPokemon.NickName = incomingUserPokemon.NickName;
            foundUserPokemon.PokemonId = incomingUserPokemon.PokemonId;
            foundUserPokemon.Level = incomingUserPokemon.Level;

            _dbContext.SaveChanges();

            return NoContent();
        }
        else
        {
            return BadRequest();
        }

    }

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult DeleteUserPokemon(int id)
    {
        UserPokemon foundUserPokemon = _dbContext.UserPokemon.SingleOrDefault(up => up.Id == id);

        if (foundUserPokemon == null)
        {
            return NotFound();
        }

        _dbContext.UserPokemon.Remove(foundUserPokemon);
        _dbContext.SaveChanges();

        return NoContent();

    }
}