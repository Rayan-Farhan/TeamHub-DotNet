namespace TeamHub.Dtos;

public class WorkspaceWithProjectsDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<ProjectDto> Projects { get; set; } = [];
}
