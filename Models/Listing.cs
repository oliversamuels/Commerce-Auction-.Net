using System.ComponentModel.DataAnnotations.Schema;
namespace Commerce.Models;

public class Listing
{
    public long ListingId {get; set;}
    public string Title {get; set; } = string.Empty;
    public string Category {get; set; } = string.Empty;
    public string Description {get; set; } = string.Empty;
    [Column(TypeName = "decimal(8, 2)")]
    public decimal StartAmount {get; set; }
    public string ImageUrl {get; set; } = string.Empty;

}