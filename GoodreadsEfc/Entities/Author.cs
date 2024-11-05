namespace GoodreadsEfc.Entities;

public class Author
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleNames { get; set; }

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Website { get; set; }

    public ICollection<Announcement> Announcements { get; set; } = new List<Announcement>();

    public ICollection<Book> Books { get; set; } = new List<Book>();

    public ICollection<Book> BooksCoAuthoreds { get; set; } = new List<Book>();
}