namespace TeamHub.Models;

public class Workspace
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    // Collection Navigation Property
    public List<Project> Projects { get; set; } = [];
}