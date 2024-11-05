namespace GoodreadsEfc.Entities;

public class Book
{
    public int Id { get; set; }

    public string? Isbn { get; set; }

    public string Title { get; set; } = null!;

    public int? PageCount { get; set; }

    public int? YearPublished { get; set; }

    public int? BindingId { get; set; }

    public int WrittenById { get; set; }

    public int? PublishedById { get; set; }

    public Binding? Binding { get; set; }

    public ICollection<BooksCurrentlyBeingRead> BooksCurrentlyBeingReads { get; set; } = new List<BooksCurrentlyBeingRead>();

    public ICollection<BooksRead> BooksReads { get; set; } = new List<BooksRead>();

    public ICollection<BooksWantedToBeRead> BooksWantedToBeReads { get; set; } = new List<BooksWantedToBeRead>();

    public Publisher? PublishedBy { get; set; }

    public Author WrittenBy { get; set; }

    public ICollection<Author> CoAuthors { get; set; } = new List<Author>();

    public ICollection<Genre> Genres { get; set; } = new List<Genre>();
}