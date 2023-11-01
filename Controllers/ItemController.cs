using Microsoft.AspNetCore.Mvc;
using PokeDokeMartRedux.Models;
using PokeDokeMartRedux.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;

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
    [Authorize]
    public IActionResult GetAllItems(string categoryId)
    {
        if (categoryId == null)
        {
            List<Item> allItems = _dbContext.Items
            .Include(i => i.Move)
            .OrderBy(i => i.CategoryId)
            .OrderBy(i => i.Id)
            .ToList();

            foreach (Item i in allItems)
            {
                i.Reviews = _dbContext.Reviews.Where(r => r.ItemId == i.Id).ToList();
            }
            //return all items
            return Ok(allItems);
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

        foreach (Item i in itemsByCategory)
        {
            i.Reviews = _dbContext.Reviews.Where(r => r.ItemId == i.Id).ToList();
        }

        return Ok(itemsByCategory);
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetSingleItem(int id)
    {
        Item foundItem = _dbContext.Items
        .Include(i => i.Move)
        .ThenInclude(m => m.DamageClass)
        .Include(i => i.Move)
        .ThenInclude(m => m.PokeType)
        .Include(i => i.Category).SingleOrDefault(i => i.Id == id);

        if (foundItem == null)
        {
            return NotFound();
        }

        foundItem.Reviews = _dbContext.Reviews.Where(r => r.ItemId == foundItem.Id).ToList();

        return Ok(foundItem);
    }

    [HttpGet("{id}/related")]
    [Authorize]
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
            amountToReturn = 5;
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
            .Where(i => (i.CategoryId == 1 || i.CategoryId == 2) && i.Id != foundItem.Id)
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

        foreach (Item i in randomizedSubset)
        {
            i.Reviews = _dbContext.Reviews.Where(r => r.ItemId == i.Id).ToList();
        }

        return Ok(randomizedSubset);
    }


    [HttpGet("suggested/userpokemon/{id}")]
    [Authorize]
    public IActionResult GetSuggestedItemsBySingleUserPokemon(int id, int amount)
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

        int amountToReturn = 0;

        if (amount == 0)
        {
            amountToReturn = 6;
        }
        else
        {
            amountToReturn = amount;
        }

        var random = new Random();

        List<Item> relatedItems = new List<Item>();

        List<Item> relatedTMs = new List<Item>();

        foreach (PokemonLearnableMove plm in foundUserPokemon.Pokemon.PokemonLearnableMoves)
        {
            Item matchedTM = _dbContext.Items.FirstOrDefault(i => i.MoveId == plm.MoveId);

            if (matchedTM != null)
            {
                relatedTMs.Add(matchedTM);
            }
        }

        int t = relatedTMs.Count;
        while (t > 1)
        {
            t--;
            int k = random.Next(t + 1);
            var temp = relatedTMs[k];
            relatedTMs[k] = relatedTMs[t];
            relatedTMs[t] = temp;
        }

        // adjust take number to control how many tms are included in the pool of suggested items to pick from ranadomly
        var randomizedTMSubset = relatedTMs.Take(8).ToList();

        relatedItems.AddRange(randomizedTMSubset);

        List<Item> matchedOtherItems = new List<Item>();

        if (foundUserPokemon.Level == 100)
        {
            matchedOtherItems = _dbContext.Items
            .Where(i => i.Name == "Hyper Potion" || i.Name == "Max Potion" || i.Name == "Full Restore" || i.Name == "Max Revive" || i.Name == "Max Ether" || i.Name == "Max Elixir").ToList();
        }
        else if (foundUserPokemon.Level < 100 && foundUserPokemon.Level >= 40)
        {
            matchedOtherItems = _dbContext.Items
            .Where(i => i.Name == "Hyper Potion" || i.Name == "Max Potion" || i.Name == "Full Restore" || i.Name == "Max Revive" || i.Name == "Max Ether" || i.Name == "Max Elixir" || i.Name == "Full Heal" || i.Name == "Rare Candy").ToList();
        }
        else if (foundUserPokemon.Level < 40 && foundUserPokemon.Level >= 20)
        {
            matchedOtherItems = _dbContext.Items
            .Where(i => i.Name == "Super Potion" || i.Name == "Revive" || i.Name == "Lemonade" || i.Name == "Fresh Water" || i.Name == "Soda Pop" || i.Name == "Ether" || i.Name == "Elixir" || i.Name == "Moomoo Milk" || i.Name == "Full Heal" || i.Name == "Rare Candy").ToList();
        }
        else if (foundUserPokemon.Level < 20)
        {
            matchedOtherItems = _dbContext.Items
            .Where(i => i.Name == "Potion" || i.Name == "Revive" || i.Name == "Fresh Water" || i.Name == "Full Heal" || i.Name == "Full Heal" || i.Name == "Ether" || i.Name == "Rare Candy" || i.Name == "Berry Juice").ToList();
        }

        relatedItems.AddRange(matchedOtherItems);

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

        foreach (Item i in randomizedSubset)
        {
            i.Reviews = _dbContext.Reviews.Where(r => r.ItemId == i.Id).ToList();
        }

        return Ok(randomizedSubset);
    }

    [HttpGet("suggested/user/{id}")]
    [Authorize]
    public IActionResult GetSuggestedItemsByUser(int id, int amount)
    {
        UserProfile foundUser = _dbContext.UserProfiles
        .Include(up => up.UserPokemon)
        .ThenInclude(up => up.Pokemon)
        .ThenInclude(p => p.PokemonLearnableMoves)
        .ThenInclude(plm => plm.Move)
        .ThenInclude(m => m.PokeType)
        .SingleOrDefault(up => up.Id == id);


        if (foundUser == null)
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

        var random = new Random();

        List<Item> relatedItems = new List<Item>();

        List<Item> relatedTMs = new List<Item>();

        foreach (UserPokemon up in foundUser.UserPokemon)
        {
            foreach (PokemonLearnableMove plm in up.Pokemon.PokemonLearnableMoves)
            {
                Item matchedTM = _dbContext.Items.FirstOrDefault(i => i.MoveId == plm.MoveId);

                if (matchedTM != null)
                {
                    relatedTMs.Add(matchedTM);
                }
            }

            int t = relatedTMs.Count;
        while (t > 1)
        {
            t--;
            int k = random.Next(t + 1);
            var temp = relatedTMs[k];
            relatedTMs[k] = relatedTMs[t];
            relatedTMs[t] = temp;
        }

        // adjust take number to control how many tms are included in the pool of suggested items to pick from ranadomly
        var randomizedTMSubset = relatedTMs.Take(8).ToList();

        relatedItems.AddRange(randomizedTMSubset);

            List<Item> matchedOtherItems = new List<Item>();

            if (up.Level == 100)
            {
                foreach (Item i in _dbContext.Items)
                {
                    if (matchedOtherItems.Any(oi => oi.Id != i.Id) && i.Name == "Hyper Potion" || i.Name == "Max Potion" || i.Name == "Full Restore" || i.Name == "Max Revive" || i.Name == "Max Ether" || i.Name == "Max Elixir")
                    {
                        matchedOtherItems.Add(i);
                    }
                }

            }
            else if (up.Level < 100 && up.Level >= 40)
            {
                foreach (Item i in _dbContext.Items)
                {
                    if (matchedOtherItems.Any(oi => oi.Id != i.Id) && i.Name == "Hyper Potion" || i.Name == "Max Potion" || i.Name == "Full Restore" || i.Name == "Max Revive" || i.Name == "Max Ether" || i.Name == "Max Elixir" || i.Name == "Full Heal" || i.Name == "Rare Candy")
                    {
                        matchedOtherItems.Add(i);
                    }
                }
            }
            else if (up.Level < 40 && up.Level >= 20)
            {
                foreach (Item i in _dbContext.Items)
                {
                    if (matchedOtherItems.Any(oi => oi.Id != i.Id) && i.Name == "Super Potion" || i.Name == "Revive" || i.Name == "Lemonade" || i.Name == "Fresh Water" || i.Name == "Soda Pop" || i.Name == "Ether" || i.Name == "Elixir" || i.Name == "Moomoo Milk" || i.Name == "Full Heal" || i.Name == "Rare Candy")
                    {
                        matchedOtherItems.Add(i);
                    }
                }
            }
            else if (up.Level < 20)
            {
                foreach (Item i in _dbContext.Items)
                {
                    if (matchedOtherItems.Any(oi => oi.Id != i.Id) && i.Name == "Potion" || i.Name == "Revive" || i.Name == "Fresh Water" || i.Name == "Full Heal" || i.Name == "Full Heal" || i.Name == "Ether" || i.Name == "Rare Candy" || i.Name == "Berry Juice")
                    {
                        matchedOtherItems.Add(i);
                    }
                }
            }

            relatedItems.AddRange(matchedOtherItems);
        }

        List<int> uniqueIds = relatedItems.Select(i => i.Id).Distinct().ToList();

        List<Item> uniqueItems = new List<Item>();

        foreach (int Id in uniqueIds)
        {
           Item matchedItem = relatedItems.First(i => i.Id == Id);
           uniqueItems.Add(matchedItem);
        }

        int n = uniqueItems.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            var temp = uniqueItems[k];
            uniqueItems[k] = uniqueItems[n];
            uniqueItems[n] = temp;
        }

        var randomizedSubset = uniqueItems.Take(amountToReturn).ToList();

        foreach (Item i in randomizedSubset)
        {
            i.Reviews = _dbContext.Reviews.Where(r => r.ItemId == i.Id).ToList();
        }

        return Ok(randomizedSubset);
    }
}