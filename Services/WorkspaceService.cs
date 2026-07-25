using TeamHub.Models;
using TeamHub.Repositories;
using TeamHub.Dtos;

namespace TeamHub.Services;

public class WorkspaceService : IWorkspaceService
{
    private readonly IWorkspaceRepository repository;

    public WorkspaceService(IWorkspaceRepository repository)
    {
        this.repository = repository;
    }

    public Workspace? GetWorkspace(int id)
    {
        return repository.GetById(id);
    }

    public Workspace CreateWorkspace(CreateWorkspaceRequest request)
    {
        return repository.Create(request.Name);
    }

    public bool UpdateWorkspace(int id, UpdateWorkspaceRequest request)
    {
        return repository.Update(id, request.Name);
    }

    public bool DeleteWorkspace(int id)
    {
        return repository.Delete(id);
    }
}