using Microsoft.EntityFrameworkCore;
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

    public async Task<List<Workspace>> GetAllAsync()
    {
        return await context.Workspaces.AsNoTracking().ToListAsync();
    }

    public async Task<Workspace?> GetByIdAsync(int id)
    {
        return await context.Workspaces.FindAsync(id);
    }

    public async Task<Workspace?> GetByIdWithProjectsAsync(int id)
    {
        return await context.Workspaces
            .AsNoTracking()
            .Include(w => w.Projects)
            .FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task<Workspace> CreateAsync(string name)
    {
        var workspace = new Workspace
        {
            Name = name
        };

        await context.Workspaces.AddAsync(workspace);
        await context.SaveChangesAsync();

        return workspace;
    }

    public async Task<bool> UpdateAsync(int id, string name)
    {
        var workspace = await GetByIdAsync(id);
        if (workspace == null)
        {
            return false;
        }

        workspace.Name = name;
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var workspace = await GetByIdAsync(id);
        if (workspace == null)
        {
            return false;
        }

        context.Workspaces.Remove(workspace);
        await context.SaveChangesAsync();

        return true;
    }
}