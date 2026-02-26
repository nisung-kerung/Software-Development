namespace Asp.Net_MVC.ViewModel
{
    public class EditUserVm
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}