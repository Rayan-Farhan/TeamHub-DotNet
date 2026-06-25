using TeamHub.Models;

namespace TeamHub.Repositories;

public class WorkspaceRepository
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
        return workspaces.FirstOrDefault(w => w.Id == id); // LINQ query to find the workspace with the given id, works similarly to python's next((w for w in workspaces if w.id == id),None)
    }
}