using TeamHub.Models;

namespace TeamHub.Repositories;

public class WorkspaceRepository : IWorkspaceRepository
{
    private static readonly List<Workspace> workspaces =
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

    public List<Workspace> GetAll()
    {
        return workspaces;
    }

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

    public bool Update(int id, string name)
    {
        var workspace = GetById(id);
        if (workspace == null)
        {
            return false;
        }

        workspace.Name = name;
        return true;
    }

    public bool Delete(int id)
    {
        var workspace = GetById(id);
        if (workspace == null)
        {
            return false;
        }

        workspaces.Remove(workspace);
        return true;
    }
}