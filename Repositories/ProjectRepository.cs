using Microsoft.EntityFrameworkCore;
using TeamHub.Data;
using TeamHub.Models;

namespace TeamHub.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly TeamHubDbContext context;

    public ProjectRepository(TeamHubDbContext context)
    {
        this.context = context;
    }

    public async Task<List<Project>> GetAllAsync()
    {
        return await context.Projects
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Project>> GetByWorkspaceIdAsync(int workspaceId)
    {
        return await context.Projects
            .AsNoTracking()
            .Where(p => p.WorkspaceId == workspaceId)
            .ToListAsync();
    }

    public async Task<Project?> GetByIdAsync(int id)
    {
        return await context.Projects.FindAsync(id);
    }

    public async Task<Project> CreateAsync(string name, string? description, int workspaceId)
    {
        var project = new Project
        {
            Name = name,
            Description = description,
            WorkspaceId = workspaceId
        };

        await context.Projects.AddAsync(project);
        await context.SaveChangesAsync();

        return project;
    }

    public async Task<bool> UpdateAsync(int id, string name, string? description)
    {
        var project = await GetByIdAsync(id);
        if (project == null)
        {
            return false;
        }

        project.Name = name;
        project.Description = description;
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var project = await GetByIdAsync(id);
        if (project == null)
        {
            return false;
        }

        context.Projects.Remove(project);
        await context.SaveChangesAsync();

        return true;
    }
}
