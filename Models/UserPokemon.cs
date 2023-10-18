namespace PokeDokeMartRedux.Models;
public class UserPokemon
{
    public int Id { get; set; }
    public string NickName { get; set; }
    public int PokemonId { get; set; }
    public Pokemon Pokemon { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    public int Level { get; set; }
}