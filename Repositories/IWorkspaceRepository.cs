using TeamHub.Models;

namespace TeamHub.Repositories;

public interface IWorkspaceRepository
{
    Workspace? GetById(int id);
    Workspace Create(string name);
    bool Update(int id, string name);
    bool Delete(int id);
}