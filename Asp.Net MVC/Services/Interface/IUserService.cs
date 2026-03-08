using Asp.Net_MVC.Models;
using Asp.Net_MVC.ViewModel;

namespace Asp.Net_MVC.Services.Interface;

public interface IUserService
{
    Task CreateUserAsync(AddUserVm vm);

    Task<List<UserModel>> GetUsersAsync();

    Task<EditUserVm?> GetUserByIdAsync(int id);

    Task EditUserAsync(EditUserVm vm);

    Task RemoveUserAsync(int id);
    
    Task ActivateUserAsync(int id);
    Task DeleteUserPermanentAsync(int id);
    
}