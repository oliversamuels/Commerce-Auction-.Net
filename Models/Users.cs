using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace Commerce.Models;

public class Users
{
    [BindProperty]
    public string UserName {get; set; } = string.Empty;

    [BindProperty]
    public string Email {get; set; } = string.Empty;

    [BindProperty]
    public string Password {get; set; } = string.Empty;
}