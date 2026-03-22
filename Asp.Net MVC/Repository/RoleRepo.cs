using Asp.Net_MVC.Data;
using Asp.Net_MVC.Entities;
using Asp.Net_MVC.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_MVC.Repository;

public class RoleRepo : IRoleRepo
{
    private readonly ApplicationDbContext _context;

    public RoleRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<Role> GetQueryable()
    {
        return _context.Roles.AsQueryable();
    }
  
    public void Commit()
    {
        _context.SaveChanges();
    }
}