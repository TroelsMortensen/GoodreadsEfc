namespace GoodreadsEfc.Entities;

public class BooksCurrentlyBeingRead
{
    public string ProfileName { get; set; } = null!;

    public int BookId { get; set; }

    public DateOnly DateStarted { get; set; }

    public Book Book { get; set; } = null!;

    public Profile ProfileNameNavigation { get; set; } = null!;
}