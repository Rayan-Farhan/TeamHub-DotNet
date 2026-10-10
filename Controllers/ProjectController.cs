using Microsoft.AspNetCore.Mvc;
using TeamHub.Dtos;
using TeamHub.Models;
using TeamHub.Services;

namespace TeamHub.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectController : ControllerBase
{
    private readonly IProjectService projectService;

    public ProjectController(IProjectService projectService)
    {
        this.projectService = projectService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAllProjects()
    {
        var projects = await projectService.GetAllProjectsAsync();
        var dtos = projects.Select(p => new ProjectDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            WorkspaceId = p.WorkspaceId
        });

        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectDto>> GetProject(int id)
    {
        var project = await projectService.GetProjectAsync(id);
        if (project == null)
        {
            return NotFound();
        }

        var dto = new ProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            WorkspaceId = project.WorkspaceId
        };

        return Ok(dto);
    }

    [HttpGet("/api/workspaces/{workspaceId}/projects")]
    public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjectsByWorkspace(int workspaceId)
    {
        var projects = await projectService.GetProjectsByWorkspaceAsync(workspaceId);
        var dtos = projects.Select(p => new ProjectDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            WorkspaceId = p.WorkspaceId
        });

        return Ok(dtos);
    }

    [HttpPost]
    public async Task<ActionResult<ProjectDto>> CreateProject(CreateProjectRequest request)
    {
        var project = await projectService.CreateProjectAsync(request);
        if (project == null)
        {
            return BadRequest($"Workspace with ID {request.WorkspaceId} does not exist.");
        }

        var dto = new ProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            WorkspaceId = project.WorkspaceId
        };

        return CreatedAtAction(
            nameof(GetProject),
            new { id = dto.Id },
            dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProject(int id, UpdateProjectRequest request)
    {
        var updated = await projectService.UpdateProjectAsync(id, request);
        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var deleted = await projectService.DeleteProjectAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
