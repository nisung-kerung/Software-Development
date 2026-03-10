using Asp.Net_MVC.Entities;

namespace Asp.Net_MVC.Repository.Interface;

public interface IUserRepo
{
    void Create(User user);

    void Update(User user);

    void Remove(User user);

    IQueryable<User> GetQueryable();

    void Commit();
}