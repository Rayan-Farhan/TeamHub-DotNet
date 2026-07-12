using TeamHub.Models;

namespace TeamHub.Repositories;

public class WorkspaceRepository : IWorkspaceRepository
{
    private readonly List<Workspace> workspaces =
    [
        new Workspace
        {
            Id = 1,
            Name = "AI Team"
        },
        new Workspace
        {
            Id = 2,
            Name = "Mobile Team"
        }
    ];

    public Workspace? GetById(int id)
    {
        return workspaces.FirstOrDefault(
            w => w.Id == id
        );
    }

    public Workspace Create(string name)
    {
        var workspace = new Workspace
        {
            Id = workspaces.Count == 0 ? 1 : workspaces.Max(w => w.Id) + 1,
            Name = name
        };

        workspaces.Add(workspace);
        return workspace;
    }
}