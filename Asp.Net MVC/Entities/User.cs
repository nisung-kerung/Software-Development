using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.Net_MVC.Entities;

[Table("users")]
public class User : BaseEntity
{
    public string Name { get; set; }

    public string? ContactNo { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string? Address { get; set; }
}