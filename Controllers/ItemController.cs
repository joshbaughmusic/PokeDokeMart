using Microsoft.AspNetCore.Mvc;
using PokeDokeMartRedux.Models;
using PokeDokeMartRedux.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

    [HttpGet("{id}/related")]
    // [Authorize]
    public IActionResult GetRelatedItems(int id, int amount)
    {
        Item foundItem = _dbContext.Items
        .Include(i => i.Category)
        .Include(i => i.Move)
        .SingleOrDefault(i => i.Id == id);

        if (foundItem == null)
        {
            return NotFound();
        }

        int amountToReturn = 0;

        if (amount == 0)
        {
            amountToReturn = 3;
        }
        else
        {
            amountToReturn = amount;
        }

        List<Item> relatedItems = new List<Item>();

        if (foundItem.CategoryId == 11)
        {
            relatedItems = _dbContext.Items
            .Include(i => i.Category)
            .Include(i => i.Move)
            .ThenInclude(m => m.DamageClass)
            .Where(i => i.Move.PokeTypeId == foundItem.Move.PokeTypeId && i.CategoryId == foundItem.CategoryId && i.Id != foundItem.Id)
            .ToList();
        }
        else if (foundItem.CategoryId == 1 || foundItem.CategoryId == 2)
        {
            relatedItems = _dbContext.Items
            .Include(i => i.Category)
            .Where(i => i.CategoryId == 1 || i.CategoryId == 2 && i.Id != foundItem.Id)
            .ToList();
        }
        else
        {
            relatedItems = _dbContext.Items
            .Include(i => i.Category)
            .Where(i => i.CategoryId == foundItem.CategoryId && i.Id != foundItem.Id)
            .ToList();
        }

        var random = new Random();
        int n = relatedItems.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            var temp = relatedItems[k];
            relatedItems[k] = relatedItems[n];
            relatedItems[n] = temp;
        }

        var randomizedSubset = relatedItems.Take(amountToReturn).ToList();

        return Ok(randomizedSubset);
    }
}