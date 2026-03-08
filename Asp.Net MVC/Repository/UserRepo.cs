using Asp.Net_MVC.Data;
using Asp.Net_MVC.Entities;
using Asp.Net_MVC.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_MVC.Repository;

public class UserRepo : IUserRepo
{
    private readonly ApplicationDbContext _context;

    public UserRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Create(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<List<User>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetById(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Update(User user)
    {
        _context.Users.Update(user);
    }
    
    public async Task DeletePermanent(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}