namespace Commerce.Models;

public class EFListingRepository : IListingRepository
{
    private DataContext context;

    public EFListingRepository(DataContext ctx)
    {
        context = ctx;
    }

    public IQueryable<Listing> Listings => context.Listings;
}