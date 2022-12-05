using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Commerce.Models;

public class Users
{
    [BindProperty]
    public string UserName {get; set; } = string.Empty;

    [BindProperty]
    [DataType(DataType.EmailAddress)]
    public string Email {get; set; } = string.Empty;

    [BindProperty]
    [DataType(DataType.Password)]
    public string Password {get; set; } = string.Empty;
}