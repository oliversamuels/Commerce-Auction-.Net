using Microsoft.EntityFrameworkCore;

namespace Commerce.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> opts) : base(opts) {}

    public DbSet<Listing> Listings => Set<Listing>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Bid> Bids => Set<Bid>();
    public DbSet<WatchList> WatchLists => Set<WatchList>();
}