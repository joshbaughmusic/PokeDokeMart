namespace PokeDokeMartRedux.Models;

public class Region
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<City> Cities { get; set; }
}