using Asp.Net_MVC.Entities;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_MVC.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}