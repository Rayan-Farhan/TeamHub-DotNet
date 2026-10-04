using TeamHub.Models;

namespace TeamHub.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<User> users =
    [
        new User
        {
            Id = 1,
            Name = "Rayan",
            Email = "rayan@test.com"
        },
        new User
        {
            Id = 2,
            Name = "Farhan",
            Email = "farhan@test.com"
        }
    ];

    public List<User> GetAll()
    {
        return users;
    }

    public User? GetById(int id)
    {
        return users.FirstOrDefault(u => u.Id == id);
    }

    public User Create(string name, string email)
    {
        var user = new User
        {
            Id = users.Count == 0 ? 1 : users.Max(u => u.Id) + 1,
            Name = name,
            Email = email
        };

        users.Add(user);
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
        return true;
    }

    public bool Delete(int id)
    {
        var user = GetById(id);
        if (user == null)
        {
            return false;
        }

        users.Remove(user);
        return true;
    }
}
