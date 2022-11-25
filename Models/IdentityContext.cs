using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Models;

public class IdentityContext : IdentityDbContext<IdentityUser> //Can choose to use a defined user class. Currently using the basic class provided by MS called "IdentityUser"
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options){ }
}