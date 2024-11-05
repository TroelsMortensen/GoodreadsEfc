using GoodreadsEfc.Entities;
using Xunit.Abstractions;

namespace GoodreadsEfc;

public class Queries(ITestOutputHelper printer)
{
    private GoodreadsContext ctx = new();

    [Fact]
    public void PrintExamples()
    {
        // this method shows printing examples.
        Author author = ctx.Authors.First();
        printer.PrintJson(author);
        printer.WriteLine("\n\n");
        
        printer.PrintObject(author);
        printer.WriteLine("\n\n");

        List<Author> authors = ctx.Authors.Take(10).ToList();
        printer.PrintList(authors);
    }
}