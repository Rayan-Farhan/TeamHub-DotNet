using TeamHub.Dtos;
using TeamHub.Models;
using TeamHub.Repositories;

namespace TeamHub.Services;

public class UserService : IUserService
{
    private readonly IUserRepository repository;

    public UserService(IUserRepository repository)
    {
        this.repository = repository;
    }

    public List<User> GetAllUsers()
    {
        return repository.GetAll();
    }

    public User? GetUser(int id)
    {
        return repository.GetById(id);
    }

    public User CreateUser(CreateUserRequest request)
    {
        return repository.Create(request.Name, request.Email);
    }

    public bool UpdateUser(int id, UpdateUserRequest request)
    {
        return repository.Update(id, request.Name, request.Email);
    }

    public bool DeleteUser(int id)
    {
        return repository.Delete(id);
    }
}
