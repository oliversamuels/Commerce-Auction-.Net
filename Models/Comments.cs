using System.ComponentModel.DataAnnotations.Schema;

namespace Commerce.Models;

public class Comments
{
    public long CommentId {get; set; }
    public string Name {get; set; } = string.Empty;
    public string Comment {get; set; } = string.Empty;
    public IEnumerable<Listing>? Listings {get; set; }
}