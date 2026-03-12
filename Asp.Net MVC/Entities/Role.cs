using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.Net_MVC.Entities;

[Table("roles")]
public class Role : BaseEntity
{
    public string Name { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
}