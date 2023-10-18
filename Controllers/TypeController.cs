using Microsoft.AspNetCore.Mvc;
using PokeDokeMartRedux.Models;
using PokeDokeMartRedux.Data;
using Microsoft.EntityFrameworkCore;

namespace PokeDokeMartRedux.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TypeController : ControllerBase
{
    private PokeDokeMartReduxDbContext _dbContext;
    public TypeController(PokeDokeMartReduxDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetAllTypes()
    {
        return Ok(_dbContext.PokeTypes);
    }
}