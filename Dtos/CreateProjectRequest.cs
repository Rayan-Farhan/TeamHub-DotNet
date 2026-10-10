using System.ComponentModel.DataAnnotations;

namespace TeamHub.Dtos;

public class CreateProjectRequest
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    [Required]
    public int WorkspaceId { get; set; }
}
