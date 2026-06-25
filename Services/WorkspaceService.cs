using TeamHub.Models;
using TeamHub.Repositories;

namespace TeamHub.Services;

public class WorkspaceService
{
    private readonly WorkspaceRepository repository;

    public WorkspaceService(WorkspaceRepository repository)
    {
        this.repository = repository;
    }

    public Workspace? GetWorkspace(int id)
    {
        return repository.GetById(id);
    }
}