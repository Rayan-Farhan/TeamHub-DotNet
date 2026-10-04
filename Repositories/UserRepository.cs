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

    public List<User> GetAll()
    {
        return context.Users.ToList();
    }

    public User? GetById(int id)
    {
        return context.Users.Find(id);
    }

    public User Create(string name, string email)
    {
        var user = new User
        {
            Name = name,
            Email = email
        };

        context.Users.Add(user);
        context.SaveChanges();

        return user;
    }

    public bool Update(int id, string name, string email)
    {
        var user = GetById(id);
        if (user == null)
        {
            return false;
        }

        user.Name = name;
        user.Email = email;
        context.SaveChanges();

        return true;
    }

    public bool Delete(int id)
    {
        var user = GetById(id);
        if (user == null)
        {
            return false;
        }

        context.Users.Remove(user);
        context.SaveChanges();

        return true;
    }
}
