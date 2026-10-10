using TeamHub.Models;

namespace TeamHub.Repositories;

public interface IProjectRepository
{
    Task<List<Project>> GetAllAsync();
    Task<List<Project>> GetByWorkspaceIdAsync(int workspaceId);
    Task<Project?> GetByIdAsync(int id);
    Task<Project> CreateAsync(string name, string? description, int workspaceId);
    Task<bool> UpdateAsync(int id, string name, string? description);
    Task<bool> DeleteAsync(int id);
}
