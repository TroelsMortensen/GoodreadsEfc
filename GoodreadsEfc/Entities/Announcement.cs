namespace GoodreadsEfc.Entities;

public class Announcement
{
    public int Id { get; set; }

    public string Content { get; set; } = null!;

    public string Title { get; set; } = null!;

    public DateTime TimeStamp { get; set; }

    public int WrittenById { get; set; }

    public Author WrittenBy { get; set; } = null!;

    public ICollection<Profile> LikedByProfilesProfileNames { get; set; } = new List<Profile>();
}