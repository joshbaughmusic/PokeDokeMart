using Microsoft.AspNetCore.Mvc;
using PokeDokeMartRedux.Models;
using PokeDokeMartRedux.Data;
using Microsoft.EntityFrameworkCore;

namespace PokeDokeMartRedux.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private PokeDokeMartReduxDbContext _dbContext;
    public ItemController(PokeDokeMartReduxDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetAllItems(string categoryId)
    {
        if (categoryId == null)
        {
            //return all items
            return Ok(_dbContext.Items
            .Include(i => i.Move));
        }
        //return items by category
        int convCategoryId = int.Parse(categoryId);

        Category foundCategory = _dbContext.Categories.SingleOrDefault(c => c.Id == convCategoryId);

        if (foundCategory == null)
        {
            return NotFound();
        }

        List<Item> itemsByCategory = _dbContext.Items
        .Include(i => i.Category)
        .Include(i => i.Move)
        .Where(i => i.CategoryId == convCategoryId)
        .OrderBy(i => i.Id)
        .ToList();

        return Ok(itemsByCategory);
    }

    [HttpGet("{id}")]
    // [Authorize]
    public IActionResult GetSingleItem(int id)
    {
        Item foundItem = _dbContext.Items
        .Include(i => i.Move)
        .ThenInclude(m => m.DamageClass)
        .Include(i => i.Category).SingleOrDefault(i => i.Id == id);

        if (foundItem == null)
        {
            return NotFound();
        }

        return Ok(foundItem);
    }
}