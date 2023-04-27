using Microsoft.EntityFrameworkCore;
using UserApp.Shared.Extensions;
using UserApp.UserApp.Domain.Models;

namespace UserApp.Shared.Persistence.Context;

public class AppDbContext : DbContext
{

    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //Users
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<User>().HasKey(user => user.UserId);
        modelBuilder.Entity<User>().Property(user => user.UserId).ValueGeneratedOnAdd();
        modelBuilder.Entity<User>().Property(user => user.Username);
        modelBuilder.Entity<User>().Property(user => user.HashedPassword);
        modelBuilder.Entity<User>().Property(user => user.Firstname);
        modelBuilder.Entity<User>().Property(user => user.Lastname);
        

        modelBuilder.ConvertAllToSnakeCase();
    }
}      