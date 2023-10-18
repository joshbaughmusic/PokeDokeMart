using Microsoft.AspNetCore.Mvc;
using PokeDokeMartRedux.Models;
using PokeDokeMartRedux.Data;
using Microsoft.EntityFrameworkCore;

namespace PokeDokeMartRedux.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DamageClassController : ControllerBase
{
    private PokeDokeMartReduxDbContext _dbContext;
    public DamageClassController(PokeDokeMartReduxDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetAllDamageClasses()
    {
        return Ok(_dbContext.DamageClasses);
    }
}