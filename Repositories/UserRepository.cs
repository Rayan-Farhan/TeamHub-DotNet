using Microsoft.EntityFrameworkCore;
using TeamHub.Data;
using TeamHub.Models;

namespace TeamHub.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TeamHubDbContext context;

    public UserRepository(TeamHubDbContext context)
    {
        this.context = context;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await context.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task<User> CreateAsync(string name, string email)
    {
        var user = new User
        {
            Name = name,
            Email = email
        };

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        return user;
    }

    public async Task<bool> UpdateAsync(int id, string name, string email)
    {
        var user = await GetByIdAsync(id);
        if (user == null)
        {
            return false;
        }

        user.Name = name;
        user.Email = email;
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await GetByIdAsync(id);
        if (user == null)
        {
            return false;
        }

        context.Users.Remove(user);
        await context.SaveChangesAsync();

        return true;
    }
}
