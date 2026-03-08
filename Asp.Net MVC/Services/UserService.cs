using Asp.Net_MVC.Entities;
using Asp.Net_MVC.Enums;
using Asp.Net_MVC.Models;
using Asp.Net_MVC.Repository.Interface;
using Asp.Net_MVC.Services.Interface;
using Asp.Net_MVC.ViewModel;

namespace Asp.Net_MVC.Services;

public class UserService : IUserService
{
    private readonly IUserRepo _repo;

    public UserService(IUserRepo repo)
    {
        _repo = repo;
    }

    public async Task CreateUserAsync(AddUserVm vm)
    {
        var user = new User
        {
            UserName = vm.Name,
            Email = vm.Email,
            Address = vm.Address,
            Password = vm.Pass
        };

        await _repo.Create(user);
        await _repo.Save();
    }

    public async Task<List<UserModel>> GetUsersAsync()
    {
        var users = await _repo.GetAll();

        return users.Select(x => new UserModel
        {
            Id = x.Id,
            UserName = x.UserName,
            Email = x.Email,
            Address = x.Address,
            Status = x.Status
        }).ToList();
    }

    public async Task<EditUserVm?> GetUserByIdAsync(int id)
    {
        var user = await _repo.GetById(id);

        if (user == null)
            return null;

        return new EditUserVm
        {
            UserId = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            Address = user.Address
        };
    }

    public async Task EditUserAsync(EditUserVm vm)
    {
        var user = await _repo.GetById(vm.UserId);

        if (user == null)
            throw new Exception("User not found");

        user.UserName = vm.UserName;
        user.Email = vm.Email;
        user.Address = vm.Address;

        await _repo.Update(user);
        await _repo.Save();
    }

    public async Task RemoveUserAsync(int id)
    {
        var user = await _repo.GetById(id);

        if (user == null)
            throw new Exception("User not found");

        user.Status = (int)StatusEnum.Inactive;

        await _repo.Update(user);
        await _repo.Save();
    }
    
    public async Task ActivateUserAsync(int id)
    {
        var user = await _repo.GetById(id);

        if (user == null)
            throw new Exception("User not found");

        user.Status = (int)StatusEnum.Active;

        await _repo.Update(user);
        await _repo.Save();
    }
    public async Task DeleteUserPermanentAsync(int id)
    {
        var user = await _repo.GetById(id);

        if (user == null)
            throw new Exception("User not found");

        await _repo.DeletePermanent(user);
    }
}