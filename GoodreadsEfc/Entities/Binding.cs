namespace GoodreadsEfc.Entities;

public class Binding
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public ICollection<Book> Books { get; set; } = new List<Book>();
}