using System.ComponentModel.DataAnnotations.Schema;

namespace Commerce.Models;

public class Comment
{
    public long CommentId {get; set; }
    public string Name {get; set; } = string.Empty;
    public string Review {get; set; } = string.Empty;
    public IEnumerable<Listing>? Listings {get; set; }
}