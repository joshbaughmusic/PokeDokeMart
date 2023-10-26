namespace PokeDokeMartRedux.Models;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public string Effect { get; set; }
    public string ShortEffect { get; set; }
    public string Description { get; set; }
    public int? MoveId { get; set; }
    public Move? Move { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public string Image { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public List<Review> Reviews { get; set; }
}