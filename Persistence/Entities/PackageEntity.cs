using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities;

public class PackageEntity
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Seating {  get; set; } = null!;
    public string Placement { get; set; } = null!;
    public decimal Price { get; set; }
    public ICollection<EventPackageEntity> EventPackages { get; set; } = [];

}
