using TeamHub.Data;
using TeamHub.Models;

namespace TeamHub.Repositories;

public class WorkspaceRepository : IWorkspaceRepository
{
    private readonly TeamHubDbContext context;

    public WorkspaceRepository(TeamHubDbContext context)
    {
        this.context = context;
    }

    public List<Workspace> GetAll()
    {
        return context.Workspaces.ToList();
    }

    public Workspace? GetById(int id)
    {
        return context.Workspaces.Find(id);
    }

    public Workspace Create(string name)
    {
        var workspace = new Workspace
        {
            Name = name
        };

        context.Workspaces.Add(workspace);
        context.SaveChanges();

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
        context.SaveChanges();

        return true;
    }

    public bool Delete(int id)
    {
        var workspace = GetById(id);
        if (workspace == null)
        {
            return false;
        }

        context.Workspaces.Remove(workspace);
        context.SaveChanges();

        return true;
    }
}