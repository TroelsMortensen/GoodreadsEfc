namespace GoodreadsEfc.Entities;

public class Address
{
    public int Id { get; set; }

    public int PublisherId { get; set; }

    public string CityName { get; set; } = null!;

    public string CityPostCode { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string HouseNumber { get; set; } = null!;

    public City City { get; set; } = null!;

    public Publisher Publisher { get; set; } = null!;
}