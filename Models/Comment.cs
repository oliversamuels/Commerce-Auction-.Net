using System.ComponentModel.DataAnnotations;

namespace Commerce.Models;

public class Comment
{
    public long CommentId {get; set; }
    public string Name {get; set; } = string.Empty;
    public string Review {get; set; } = string.Empty;
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd-MM-yyyy hh:mm tt}")]
    public DateTime DateAdded { get; set; } = DateTime.Now;
    public long ListingId {get; set; }
    public virtual Listing? Listing { get; set; }
}