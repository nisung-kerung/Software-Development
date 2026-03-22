using Asp.Net_MVC.Dtos;
using Asp.Net_MVC.Entities;

namespace Asp.Net_MVC.Services.Interface;

public interface IUserService
{
    void AddUser(NewUserDto dto);

    void EditUser(User user, UserEditDto dto);

    void RemoveUser(User user);
    void ActivateUser(User user);

    void PermanentDelete(User user);


    User GetUser(string username, string password);
   
    
    void AssignRole(long userId, long roleId);
}