namespace GoodreadsEfc.Entities;

public class City
{
    public string PostCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public ICollection<Address> Addresses { get; set; } = new List<Address>();
}