using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.Net_MVC.Entities;

[Table("user_roles")]
public class UserRole : BaseEntity
{
    public long UserId { get; set; }
    public User User { get; set; }

    public long RoleId { get; set; }
    public Role Role { get; set; }
}