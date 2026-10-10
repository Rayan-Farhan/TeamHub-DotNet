using TeamHub.Dtos;
using TeamHub.Models;

namespace TeamHub.Services;

public interface IWorkspaceService
{
    Task<List<Workspace>> GetAllWorkspacesAsync();
    Task<Workspace?> GetWorkspaceAsync(int id);
    Task<Workspace> CreateWorkspaceAsync(CreateWorkspaceRequest request);
    Task<bool> UpdateWorkspaceAsync(int id, UpdateWorkspaceRequest request);
    Task<bool> DeleteWorkspaceAsync(int id);
}
