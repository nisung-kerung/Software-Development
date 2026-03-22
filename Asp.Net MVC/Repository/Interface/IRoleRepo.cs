using Asp.Net_MVC.Entities;

namespace Asp.Net_MVC.Repository.Interface;

public interface IRoleRepo
{
    IQueryable<Role> GetQueryable();
    

    void Commit();
}