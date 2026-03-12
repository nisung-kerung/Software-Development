using Asp.Net_MVC.Entities;

namespace Asp.Net_MVC.Repository.Interface;

public interface IUserRoleRepo
{
    IQueryable<UserRole> GetQueryable();

    void Create(UserRole userRole);

    void Commit();
}