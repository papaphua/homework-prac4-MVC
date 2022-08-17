using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models;

public class UserModel
{
    [Key]
    public int UserId { get; set; }
    [DisplayName("First Name")]
    public string FirstName { get; set; } = string.Empty;
    [DisplayName("Last Name")]
    public string LastName { get; set; } = string.Empty;    
    [DisplayName("Email")]
    public string Email { get; set; } = string.Empty;
}