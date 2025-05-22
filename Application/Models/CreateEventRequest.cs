
namespace Application.Models;

public class CreateEventRequest
{
    public string Title { get; set; } = null!;
    public string Date { get; set; } = null!;
    public string Location { get; set; } = null!;
    public decimal Price { get; set; }


}
