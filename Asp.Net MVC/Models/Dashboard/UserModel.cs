namespace Asp.Net_MVC.Models.Dashboard
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public UserStatus Status { get; set; } = UserStatus.Active;
    }
}