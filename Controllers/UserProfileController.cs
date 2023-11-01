using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokeDokeMartRedux.Data;
using Microsoft.EntityFrameworkCore;
using PokeDokeMartRedux.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace PokeDokeMartRedux.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private PokeDokeMartReduxDbContext _dbContext;
    private readonly UserManager<IdentityUser> _userManager;


    public UserProfileController(PokeDokeMartReduxDbContext context, UserManager<IdentityUser> userManager)
    {
        _dbContext = context;
        _userManager = userManager;

    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext.UserProfiles.ToList());
    }

    [HttpGet("withroles")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetWithRoles()
    {
        return Ok(_dbContext.UserProfiles
        .Include(up => up.IdentityUser)
        .Select(up => new UserProfile
        {
            Id = up.Id,
            FirstName = up.FirstName,
            LastName = up.LastName,
            Address = up.Address,
            Email = up.IdentityUser.Email,
            UserName = up.IdentityUser.UserName,
            IdentityUserId = up.IdentityUserId,
            Roles = _dbContext.UserRoles
            .Where(ur => ur.UserId == up.IdentityUserId)
            .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
            .ToList()
        }));
    }

    [HttpGet("me")]
    [Authorize]
    public IActionResult GetCurrentUserProfile()
    {

        var loggedInUser = _dbContext
             .UserProfiles
             .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);


        if (loggedInUser != null)
        {

            UserProfile foundUserProfile = _dbContext.UserProfiles
            .Include(up => up.IdentityUser)
            .Include(up => up.Region)
            .Include(up => up.City)
            .Include(up => up.UserPokemon)
            .ThenInclude(up => up.Pokemon)
            .Include(up => up.Orders)
            .ThenInclude(o => o.OrderItems)
            .ThenInclude(oi => oi.Item)
            .Select(up => new UserProfile
            {
                Id = up.Id,
                ProfilePictureUrl = up.ProfilePictureUrl,
                FirstName = up.FirstName,
                LastName = up.LastName,
                Address = up.Address,
                RegionId = up.RegionId,
                Region = up.Region,
                CityId = up.CityId,
                City = up.City,
                Email = up.IdentityUser.Email,
                UserName = up.IdentityUser.UserName,
                UserPokemon = up.UserPokemon,
                Orders = up.Orders
            })
            .SingleOrDefault(up => up.Id == loggedInUser.Id);

            return Ok(foundUserProfile);
        }
        return NotFound();
    }

    [HttpPut("update")]
    [Authorize]

    public IActionResult UpdateUserProfile(UserProfile updatedUserProfile)
    {
        var loggedInUser = _dbContext
            .UserProfiles
            .SingleOrDefault(up => up.IdentityUserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        UserProfile foundUserProfile = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == loggedInUser.Id);

        var idUser = _dbContext.Users.Single(u => u.Id == foundUserProfile.IdentityUserId);

        if (foundUserProfile == null)
        {
            return NotFound();
        }

        idUser.Email = updatedUserProfile.Email;
        foundUserProfile.FirstName = updatedUserProfile.FirstName;
        foundUserProfile.LastName = updatedUserProfile.LastName;
        foundUserProfile.Address = updatedUserProfile.Address;
        foundUserProfile.RegionId = updatedUserProfile.RegionId;
        foundUserProfile.CityId = updatedUserProfile.CityId;

        if (updatedUserProfile.ProfilePictureUrl != "") 
        {
        foundUserProfile.ProfilePictureUrl = updatedUserProfile.ProfilePictureUrl;
        }

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPost("promote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Promote(string id)
    {
        IdentityRole role = _dbContext.Roles.SingleOrDefault(r => r.Name == "Admin");

        _dbContext.UserRoles.Add(new IdentityUserRole<string>
        {
            RoleId = role.Id,
            UserId = id
        });
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpPost("demote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Demote(string id)
    {
        IdentityRole role = _dbContext.Roles
            .SingleOrDefault(r => r.Name == "Admin");
        IdentityUserRole<string> userRole = _dbContext
            .UserRoles
            .SingleOrDefault(ur =>
                ur.RoleId == role.Id &&
                ur.UserId == id);

        _dbContext.UserRoles.Remove(userRole);
        _dbContext.SaveChanges();
        return NoContent();
    }

}