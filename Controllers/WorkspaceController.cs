using Microsoft.AspNetCore.Mvc;
using TeamHub.Models;
using TeamHub.Services;

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
}