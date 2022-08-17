using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models;

public class UserModel
{
    [Key]
    public int UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;    
    public string Email { get; set; } = string.Empty;
}