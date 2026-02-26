using Asp.Net_MVC.Models.Dashboard;
using Asp.Net_MVC.Services.Interface;

namespace Asp.Net_MVC.Services
{
    public class UserService : IUserService
    {
        private static List<UserModel> _list = new List<UserModel>
        {
            new UserModel { Id = Guid.NewGuid(), UserName = "Admin", Phone="9800000000", Status = UserStatus.Active },
            new UserModel { Id = Guid.NewGuid(), UserName = "Technician", Phone="9811111111", Status = UserStatus.Active },
            new UserModel { Id = Guid.NewGuid(), UserName = "Old Staff", Phone="9822222222", Status = UserStatus.Inactive }
        };

        public List<UserModel> GetAllUsers() => _list;

        public List<UserModel> GetActiveUsers() =>
            _list.Where(x => x.Status == UserStatus.Active).ToList();

        public List<UserModel> GetInactiveUsers() =>
            _list.Where(x => x.Status == UserStatus.Inactive).ToList();

        public UserModel GetById(Guid id) =>
            _list.FirstOrDefault(x => x.Id == id);

        public void Create(UserModel user)
        {
            user.Id = Guid.NewGuid();
            _list.Add(user);
        }

        public void Update(UserModel user)
        {
            var existing = GetById(user.Id);
            if (existing == null) return;

            existing.UserName = user.UserName;
            existing.Phone = user.Phone;
            existing.Status = user.Status;
        }

        public void Delete(Guid id)
        {
            var user = GetById(id);
            if (user != null)
                _list.Remove(user);
        }

        public void Activate(Guid id)
        {
            var user = GetById(id);
            if (user != null)
                user.Status = UserStatus.Active;
        }

        public void Deactivate(Guid id)
        {
            var user = GetById(id);
            if (user != null)
                user.Status = UserStatus.Inactive;
        }
    }
}