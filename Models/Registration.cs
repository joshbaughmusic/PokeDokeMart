namespace PokeDokeMartRedux.Models;
public class Registration
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public int RegionId { get; set; }
    public int CityId { get; set; }
}