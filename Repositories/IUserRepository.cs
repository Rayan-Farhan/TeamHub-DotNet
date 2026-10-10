using TeamHub.Models;

namespace TeamHub.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task<User> CreateAsync(string name, string email);
    Task<bool> UpdateAsync(int id, string name, string email);
    Task<bool> DeleteAsync(int id);
}
