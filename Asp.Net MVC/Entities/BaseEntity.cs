using System.ComponentModel.DataAnnotations;
using Asp.Net_MVC.Enums;

namespace Asp.Net_MVC.Entities;

public class BaseEntity
{
    [Key]
    public long Id { get; set; }

    public DateTime RecDate { get; set; } = DateTime.UtcNow;

    public StatusEnum Status { get; set; } = StatusEnum.Active;

    public RecStatusEnum RecStatus { get; set; } = RecStatusEnum.Active;
}