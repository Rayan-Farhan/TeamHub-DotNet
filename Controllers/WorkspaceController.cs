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
    public async Task<ActionResult<IEnumerable<Workspace>>> GetAllWorkspaces()
    {
        var workspaces = await workspaceService.GetAllWorkspacesAsync();
        return Ok(workspaces);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWorkspace(int id)
    {
        var workspace = await workspaceService.GetWorkspaceAsync(id);
        if (workspace == null)
        {
            return NotFound();
        }
        return Ok(workspace);
    }

    [HttpPost]
    public async Task<ActionResult<Workspace>> CreateWorkspace(CreateWorkspaceRequest request)
    {
        var workspace = await workspaceService.CreateWorkspaceAsync(request);

        return CreatedAtAction(
            nameof(GetWorkspace),
            new { id = workspace.Id },
            workspace);
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