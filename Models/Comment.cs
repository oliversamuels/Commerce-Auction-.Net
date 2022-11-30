using System.ComponentModel.DataAnnotations;

namespace Commerce.Models;

public class Comment
{
    public long CommentId {get; set; }
    public string Name {get; set; } = string.Empty;
    public string Review {get; set; } = string.Empty;
    public long ListingId {get; set; }
    public virtual Listing? Listing { get; set; }
}