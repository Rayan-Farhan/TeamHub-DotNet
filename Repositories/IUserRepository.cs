using TeamHub.Models;

namespace TeamHub.Repositories;

public interface IUserRepository
{
    List<User> GetAll();
    User? GetById(int id);
    User Create(string name, string email);
    bool Update(int id, string name, string email);
    bool Delete(int id);
}
