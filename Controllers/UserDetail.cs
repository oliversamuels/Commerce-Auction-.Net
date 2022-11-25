using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Commerce.Models;

namespace Commerce.Controllers;

public class UserDetails
{
    private UserManager<IdentityUser> userManager;

    public UserDetails(UserManager<IdentityUser> manager)
    {
        userManager = manager;
    }

    public IdentityUser? IdentityUser {get; set; }
    
}