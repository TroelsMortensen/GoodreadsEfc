namespace GoodreadsEfc.Entities;

public class Profile
{
    public string ProfileName { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public ICollection<BooksCurrentlyBeingRead> BooksCurrentlyBeingReads { get; set; } = new List<BooksCurrentlyBeingRead>();

    public ICollection<BooksRead> BooksReads { get; set; } = new List<BooksRead>();

    public ICollection<BooksWantedToBeRead> BooksWantedToBeReads { get; set; } = new List<BooksWantedToBeRead>();

    public ICollection<Announcement> AnnouncementsLikeds { get; set; } = new List<Announcement>();
}