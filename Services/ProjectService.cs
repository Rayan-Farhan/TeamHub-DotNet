using TeamHub.Dtos;
using TeamHub.Models;
using TeamHub.Repositories;

namespace TeamHub.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository projectRepository;
    private readonly IWorkspaceRepository workspaceRepository;

    public ProjectService(
        IProjectRepository projectRepository,
        IWorkspaceRepository workspaceRepository)
    {
        this.projectRepository = projectRepository;
        this.workspaceRepository = workspaceRepository;
    }

    public async Task<List<Project>> GetAllProjectsAsync()
    {
        return await projectRepository.GetAllAsync();
    }

    public async Task<List<Project>> GetProjectsByWorkspaceAsync(int workspaceId)
    {
        return await projectRepository.GetByWorkspaceIdAsync(workspaceId);
    }

    public async Task<Project?> GetProjectAsync(int id)
    {
        return await projectRepository.GetByIdAsync(id);
    }

    public async Task<Project?> CreateProjectAsync(CreateProjectRequest request)
    {
        // Business Rule: Ensure the target Workspace actually exists
        var workspace = await workspaceRepository.GetByIdAsync(request.WorkspaceId);
        if (workspace == null)
        {
            return null;
        }

        return await projectRepository.CreateAsync(
            request.Name,
            request.Description,
            request.WorkspaceId);
    }

    public async Task<bool> UpdateProjectAsync(int id, UpdateProjectRequest request)
    {
        return await projectRepository.UpdateAsync(
            id,
            request.Name,
            request.Description);
    }

    public async Task<bool> DeleteProjectAsync(int id)
    {
        return await projectRepository.DeleteAsync(id);
    }
}
