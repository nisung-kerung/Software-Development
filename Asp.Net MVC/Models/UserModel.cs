using Asp.Net_MVC.Enums;

namespace Asp.Net_MVC.Models;

public class UserModel
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public int Status { get; set; } = (int)StatusEnum.Active;
}