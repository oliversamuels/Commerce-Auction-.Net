using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Commerce.Models;

public class Listing
{
    public long ListingId {get; set;}
    public string Title {get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Category {get; set; } = string.Empty;
    public string Description {get; set; } = string.Empty;
    [Column(TypeName = "decimal(8, 2)")]
    public decimal StartAmount {get; set; }
    public string ImageUrl {get; set; } = string.Empty;
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd-MM-yyyy hh:mm tt}")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [DefaultValue(true)]
    public bool ActiveStatus { get; set; } = true;
    [ForeignKey("comments")]
    public virtual ICollection<Comment>? Comments { get; set; }
    [ForeignKey("bids")]
    public virtual Bid? Bids { get; set; }
    [ForeignKey("watchlist")]
    public virtual ICollection<WatchList>? WatchLists { get; set; }

}