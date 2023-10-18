namespace PokeDokeMartRedux.Models;
public class Pokemon
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public List<PokemonType> PokemonTypes { get; set; }
    public List<PokemonLearnableMove> PokemonLearnableMoves { get; set; }
}