namespace PokeDokeMartRedux.Models;
public class Move
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Accuracy { get; set; }
    public int? Power { get; set; }
    public int? PP { get; set; }
    public int DamageClassId { get; set; }
    public DamageClass DamageClass { get; set; }
    public int PokeTypeId { get; set; }
    public PokeType PokeType { get; set; }
}