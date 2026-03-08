using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.Net_MVC.Entities;

[Table("users", Schema = "public")]
public class User : BaseEntity
{
    public required string UserName { get; set; }

    public string? Email { get; set; }

    public required string Password { get; set; }

    public string? Address { get; set; }
}