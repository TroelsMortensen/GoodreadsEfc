namespace GoodreadsEfc.Entities;

public class Genre
{
    public int Id { get; set; }

    public string GenreName { get; set; } = null!;

    public ICollection<Book> DescribedBooks { get; set; } = new List<Book>();
}