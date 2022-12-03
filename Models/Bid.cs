namespace Commerce.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

public class Bid
{
    public long BidId {get; set; }
    [Column(TypeName = "decimal(8, 2)")]
    public decimal Amount {get; set; }
    public string? UserName { get; set; }
    public long ListingId { get; set; }
    public virtual Listing? Listing { get; set; }
}