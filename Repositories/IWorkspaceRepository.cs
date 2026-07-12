using TeamHub.Models;

namespace TeamHub.Repositories;

public interface IWorkspaceRepository
{
    Workspace? GetById(int id);
    Workspace Create(string name);
}