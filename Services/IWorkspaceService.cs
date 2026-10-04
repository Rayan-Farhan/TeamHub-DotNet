using TeamHub.Dtos;
using TeamHub.Models;

namespace TeamHub.Services;

public interface IWorkspaceService
{
    List<Workspace> GetAllWorkspaces();
    Workspace? GetWorkspace(int id);
    Workspace CreateWorkspace(CreateWorkspaceRequest request);
    bool UpdateWorkspace(int id, UpdateWorkspaceRequest request);
    bool DeleteWorkspace(int id);
}
