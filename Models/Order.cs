namespace PokeDokeMartRedux.Models;
public class Order
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    public DateTime Date { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}