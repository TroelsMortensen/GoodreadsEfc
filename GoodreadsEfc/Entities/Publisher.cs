namespace GoodreadsEfc.Entities;

public class Publisher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public Address? Address { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>();
}