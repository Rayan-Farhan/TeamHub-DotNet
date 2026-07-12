using Microsoft.AspNetCore.Mvc;
using TeamHub.Models;
using TeamHub.Services;
using TeamHub.Dtos;

namespace TeamHub.Controllers;

[ApiController]
[Route("api/workspaces")]
public class WorkspaceController : ControllerBase
{
    private readonly WorkspaceService workspaceService;

    public WorkspaceController(WorkspaceService workspaceService)
    {
        this.workspaceService = workspaceService;
    }

    [HttpGet("{id}")]
    public IActionResult GetWorkspace(int id)
    {
        var workspace = workspaceService.GetWorkspace(id);
        if (workspace == null)
        {
            return NotFound();
        }
        return Ok(workspace);
    }

    [HttpPost]
    public ActionResult<Workspace> CreateWorkspace(CreateWorkspaceRequest request)
    {
        var workspace = workspaceService.CreateWorkspace(request);

        return CreatedAtAction(
            nameof(GetWorkspace),
            new { id = workspace.Id },
            workspace);
    }
}