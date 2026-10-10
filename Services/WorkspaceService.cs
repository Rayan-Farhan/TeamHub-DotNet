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

    public async Task<List<Workspace>> GetAllWorkspacesAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<Workspace?> GetWorkspaceAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<WorkspaceWithProjectsDto?> GetWorkspaceWithProjectsAsync(int id)
    {
        var workspace = await repository.GetByIdWithProjectsAsync(id);
        if (workspace == null)
        {
            return null;
        }

        return new WorkspaceWithProjectsDto
        {
            Id = workspace.Id,
            Name = workspace.Name,
            Projects = workspace.Projects.Select(p => new ProjectDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                WorkspaceId = p.WorkspaceId
            }).ToList()
        };
    }

    public async Task<Workspace> CreateWorkspaceAsync(CreateWorkspaceRequest request)
    {
        return await repository.CreateAsync(request.Name);
    }

    public async Task<bool> UpdateWorkspaceAsync(int id, UpdateWorkspaceRequest request)
    {
        return await repository.UpdateAsync(id, request.Name);
    }

    public async Task<bool> DeleteWorkspaceAsync(int id)
    {
        return await repository.DeleteAsync(id);
    }
}