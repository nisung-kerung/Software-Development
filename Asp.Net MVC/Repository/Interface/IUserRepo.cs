using Asp.Net_MVC.Entities;

namespace Asp.Net_MVC.Repository.Interface;

public interface IUserRepo
{
    Task Create(User user);

    Task<List<User>> GetAll();

    Task<User?> GetById(int id);

    Task Update(User user);
    Task DeletePermanent(User user);
    Task Save();
}