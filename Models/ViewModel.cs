using System.ComponentModel.DataAnnotations.Schema;
namespace Commerce.Models;

public class ViewModel
{
    public int ListingId { get; set; }
    public string? Title {get; set; }
    [Column(TypeName = "decimal(8, 2)")]
    public decimal StartAmount {get; set; }
    public bool ActiveStatus { get; set; }
}