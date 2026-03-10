using Asp.Net_MVC.Data;
using Asp.Net_MVC.Entities;
using Asp.Net_MVC.Repository.Interface;

namespace Asp.Net_MVC.Repository;

public class UserRepo : IUserRepo
{
    private readonly ApplicationDbContext _context;

    public UserRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Create(User user)
    {
        _context.Users.Add(user);
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
    }

    public void Remove(User user)
    {
        _context.Users.Remove(user);
    }

    public IQueryable<User> GetQueryable()
    {
        return _context.Users.AsQueryable();
    }

    public void Commit()
    {
        _context.SaveChanges();
    }
}