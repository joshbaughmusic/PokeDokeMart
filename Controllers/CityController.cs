using Microsoft.AspNetCore.Mvc;
using PokeDokeMartRedux.Models;
using PokeDokeMartRedux.Data;
using Microsoft.EntityFrameworkCore;

namespace PokeDokeMartRedux.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CityController : ControllerBase
{
    private PokeDokeMartReduxDbContext _dbContext;
    public CityController(PokeDokeMartReduxDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetAllCities()
    {
        return Ok(_dbContext.Cities);
    }

    [HttpGet("{id}")]
    // [Authorize]
    public IActionResult GetSingleCity(int id)
    {
        City foundCity = _dbContext.Cities.SingleOrDefault(c => c.Id == id);
        if (foundCity == null)
        {
            return NotFound();
        }
        return Ok(foundCity);
    }

    [HttpGet("region/{id}")]
    // [Authorize]
    public IActionResult GetCitiesByRegionId(int id)
    {
        List<City> foundCities = _dbContext.Cities.Where(c => c.RegionId == id).ToList();
        if (foundCities.Count == 0)
        {
            return NotFound();
        }
        return Ok(foundCities);
    }
}