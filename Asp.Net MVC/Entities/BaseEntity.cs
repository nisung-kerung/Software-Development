using System.ComponentModel.DataAnnotations;
using Asp.Net_MVC.Enums;

namespace Asp.Net_MVC.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }

    public DateTime RecDate { get; set; } = DateTime.UtcNow;

    public int Status { get; set; } = (int)StatusEnum.Active;

    public char RecStatus { get; set; } = (char)RecStatusEnum.Active;
}