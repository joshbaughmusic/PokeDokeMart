namespace PokeDokeMartRedux.Models;
public class PokemonLearnableMove
{
    public int Id { get; set; }
    public int PokemonId { get; set; }
    public Pokemon Pokemon { get; set; }
    public int MoveId { get; set; }
    public Move Move { get; set; }
}