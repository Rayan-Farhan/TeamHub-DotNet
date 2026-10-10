namespace TeamHub.Models;

public class Project
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    // Foreign Key
    public int WorkspaceId { get; set; }

    // Reference Navigation Property
    public Workspace? Workspace { get; set; }
}
