using TeamHub.Dtos;
using TeamHub.Models;

namespace TeamHub.Services;

public interface IProjectService
{
    Task<List<Project>> GetAllProjectsAsync();
    Task<List<Project>> GetProjectsByWorkspaceAsync(int workspaceId);
    Task<Project?> GetProjectAsync(int id);
    Task<Project?> CreateProjectAsync(CreateProjectRequest request);
    Task<bool> UpdateProjectAsync(int id, UpdateProjectRequest request);
    Task<bool> DeleteProjectAsync(int id);
}
