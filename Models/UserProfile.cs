using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace PokeDokeMartRedux.Models;
public class UserProfile
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string ProfilePictureUrl { get; set; }
    [NotMapped]
    public string Email { get; set; }
    [NotMapped]
    public string UserName { get; set; }
    [NotMapped]
    public List<string> Roles { get; set; }
    [NotMapped]
    public List<UserPokemon> UserPokemon { get; set; }
    public List<Order> Orders { get; set; }
    public string IdentityUserId { get; set; }
    public IdentityUser IdentityUser { get; set; }
}