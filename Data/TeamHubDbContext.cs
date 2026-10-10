using Microsoft.EntityFrameworkCore;
using TeamHub.Models;

namespace TeamHub.Data;

public class TeamHubDbContext : DbContext
{
    public TeamHubDbContext(DbContextOptions<TeamHubDbContext> options)
        : base(options)
    {
    }

    public DbSet<Workspace> Workspaces { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
}
