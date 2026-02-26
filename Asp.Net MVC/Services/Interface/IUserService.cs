using Asp.Net_MVC.Models.Dashboard;

namespace Asp.Net_MVC.Services.Interface
{
    public interface IUserService
    {
        List<UserModel> GetAllUsers();
        List<UserModel> GetActiveUsers();
        List<UserModel> GetInactiveUsers();
        UserModel GetById(Guid id);

        void Create(UserModel user);
        void Update(UserModel user);
        void Delete(Guid id);

        void Activate(Guid id);
        void Deactivate(Guid id);
    }
}