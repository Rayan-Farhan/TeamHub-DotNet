using System.ComponentModel.DataAnnotations;

namespace TeamHub.Dtos;

public class UpdateWorkspaceRequest
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
}
