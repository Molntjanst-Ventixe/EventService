
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models;

public class Event
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Date { get; set; } = null!;
    public string Location { get; set; } = null!;
    public decimal Price { get; set; }
}
