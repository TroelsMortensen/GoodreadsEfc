namespace GoodreadsEfc.Entities;

public class BooksRead
{
    public int BookId { get; set; }

    public string ProfileName { get; set; } = null!;

    public DateOnly? DateFinished { get; set; }

    public DateOnly? DateStarted { get; set; }

    public int? Rating { get; set; }

    public string? Review { get; set; }

    public Book Book { get; set; } = null!;

    public Profile ProfileNameNavigation { get; set; } = null!;
}