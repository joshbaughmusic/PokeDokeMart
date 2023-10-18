namespace PokeDokeMartRedux.Models;
public class Review
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    public int ItemId { get; set; }
    public Item Item { get; set; }
    public int Rating { get; set; }
    public string Body { get; set; }
    public DateTime Date { get; set; }
}