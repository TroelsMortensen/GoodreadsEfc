namespace GoodreadsEfc.Entities;

public class BooksWantedToBeRead
{
    public string ProfileName { get; set; } = null!;

    public int BookId { get; set; }

    public DateOnly? DateAdded { get; set; }

    public Book Book { get; set; } = null!;

    public Profile ProfileNameNavigation { get; set; } = null!;
}