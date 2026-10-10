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

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<User?> GetUserAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<User> CreateUserAsync(CreateUserRequest request)
    {
        return await repository.CreateAsync(request.Name, request.Email);
    }

    public async Task<bool> UpdateUserAsync(int id, UpdateUserRequest request)
    {
        return await repository.UpdateAsync(id, request.Name, request.Email);
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        return await repository.DeleteAsync(id);
    }
}
