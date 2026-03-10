using Asp.Net_MVC.Dtos;
using Asp.Net_MVC.Entities;
using Asp.Net_MVC.Enums;
using Asp.Net_MVC.Repository.Interface;
using Asp.Net_MVC.Services.Interface;

namespace Asp.Net_MVC.Services;

public class UserService : IUserService
{
    private readonly IUserRepo _userRepo;

    public UserService(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    public void AddUser(NewUserDto dto)
    {
        var user = new User
        {
            Name = dto.Name,
            ContactNo = dto.ContactNo,
            Username = dto.UserName,
            Email = dto.Email ?? "",
            Address = dto.Address,
            Password = dto.Password
        };

        _userRepo.Create(user);
        _userRepo.Commit();
    }

    public void EditUser(User user, UserEditDto dto)
    {
        user.Name = dto.Name;
        user.ContactNo = dto.ContactNo;
        user.Username = dto.UserName;
        user.Email = dto.Email;
        user.Address = dto.Address;

        _userRepo.Update(user);
        _userRepo.Commit();
    }

    public void RemoveUser(User user)
    {
        user.Status = StatusEnum.Inactive;
        _userRepo.Update(user);
        _userRepo.Commit();
    }
    // Activate user
    public void ActivateUser(User user)
    {
        user.Status = StatusEnum.Active;
        _userRepo.Update(user);
        _userRepo.Commit();
    }

    // Permanent delete
    public void PermanentDelete(User user)
    {
        _userRepo.Remove(user);
        _userRepo.Commit();
    }

    public User GetUser(string username, string password)
    {
        username = username.Trim().ToLower();
        password = password.Trim().ToLower();

        var user = _userRepo.GetQueryable()
            .FirstOrDefault(x =>
                (x.Username.ToLower() == username || x.Email.ToLower() == username)
                && x.Password.ToLower() == password);

        if (user == null)
            throw new Exception("Invalid Credentials");

        return user;
    }
}