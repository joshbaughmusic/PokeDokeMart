namespace PokeDokeMartRedux.Models;
public class Order
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    public DateTime Date { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public decimal Total
    {
        get
        {
            return OrderItems.Select(oi => oi.Quantity * oi.Item.Cost).Sum();
        }
    }
    public string FirstName { get; set; }
    public string MiddleInitial { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
    public int RegionId { get; set; }
    public Region Region { get; set; }
}