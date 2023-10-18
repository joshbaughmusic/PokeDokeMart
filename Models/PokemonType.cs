namespace PokeDokeMartRedux.Models;
public class PokemonType
{
    public int Id { get; set; }
    public int PokemonId { get; set; }
    public Pokemon Pokemon { get; set; }
    public int PokeTypeId { get; set; }
    public PokeType PokeType { get; set; }
}