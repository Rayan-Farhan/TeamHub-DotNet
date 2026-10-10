using Microsoft.AspNetCore.Mvc;
using TeamHub.Models;
using TeamHub.Services;
using TeamHub.Dtos;

namespace TeamHub.Controllers;

[ApiController]
[Route("api/workspaces")]
public class WorkspaceController : ControllerBase
{
    private readonly IWorkspaceService workspaceService;

    public WorkspaceController(IWorkspaceService workspaceService)
    {
        this.workspaceService = workspaceService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkspaceDto>>> GetAllWorkspaces()
    {
        var workspaces = await workspaceService.GetAllWorkspacesAsync();
        var dtos = workspaces.Select(w => new WorkspaceDto
        {
            Id = w.Id,
            Name = w.Name
        });

        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WorkspaceDto>> GetWorkspace(int id)
    {
        var workspace = await workspaceService.GetWorkspaceAsync(id);
        if (workspace == null)
        {
            return NotFound();
        }

        var dto = new WorkspaceDto
        {
            Id = workspace.Id,
            Name = workspace.Name
        };

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<WorkspaceDto>> CreateWorkspace(CreateWorkspaceRequest request)
    {
        var workspace = await workspaceService.CreateWorkspaceAsync(request);

        var dto = new WorkspaceDto
        {
            Id = workspace.Id,
            Name = workspace.Name
        };

        return CreatedAtAction(
            nameof(GetWorkspace),
            new { id = dto.Id },
            dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWorkspace(int id, UpdateWorkspaceRequest request)
    {
        var updated = await workspaceService.UpdateWorkspaceAsync(id, request);
        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkspace(int id)
    {
        var deleted = await workspaceService.DeleteWorkspaceAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}