using Asp.Net_MVC.Data;
using Asp.Net_MVC.Entities;
using Asp.Net_MVC.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_MVC.Repository;

public class UserRoleRepo : IUserRoleRepo
{
    private readonly ApplicationDbContext _context;

    public UserRoleRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<UserRole> GetQueryable()
    {
        return _context.UserRoles.AsQueryable();
    }

    public void Create(UserRole userRole)
    {
        _context.UserRoles.Add(userRole);
    }
    
    public void Commit()
    {
        _context.SaveChanges();
    }
}