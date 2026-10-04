using TeamHub.Dtos;
using TeamHub.Models;

namespace TeamHub.Services;

public interface IUserService
{
    List<User> GetAllUsers();
    User? GetUser(int id);
    User CreateUser(CreateUserRequest request);
    bool UpdateUser(int id, UpdateUserRequest request);
    bool DeleteUser(int id);
}
