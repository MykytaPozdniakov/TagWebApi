using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TagWebApi.Application.DTOs;
using static ProjectRepository;

[ApiController]
[Route("[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectRepository _projectRepository;
    private readonly IProjectAssignmentRepository _projectAssignmentRepository;
    private readonly IMapper _mapper;


    public ProjectsController(IProjectRepository projectRepository, IProjectAssignmentRepository projectAssignmentRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _projectAssignmentRepository = projectAssignmentRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProjects()
    {
        var projects = await _projectRepository.GetAllProjects();
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProjectById(int id)
    {
        var project = await _projectRepository.GetProjectById(id);
        if (project == null)
        {
            return NotFound();
        }
        return Ok(project);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetProjectsByUserId(int userId)
    {
        var projects = await _projectAssignmentRepository.GetAssignmentByUserId(userId);
        if (projects == null)
        {
            return NotFound();
        }

        var assignments = _mapper.Map<ProjectAssignmentDto>(projects);
        return Ok(assignments);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProject(Project project)
    {
        await _projectRepository.CreateProject(project);
        return CreatedAtAction(nameof(GetProjectById), new { id = project.Id }, project);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProject(int id, Project project)
    {
        if (id != project.Id)
        {
            return BadRequest();
        }

        var existingProject = await _projectRepository.GetProjectById(id);
        if (existingProject == null)
        {
            return NotFound();
        }

        await _projectRepository.UpdateProject(project);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var project = await _projectRepository.GetProjectById(id);
        if (project == null)
        {
            return NotFound();
        }

        await _projectRepository.DeleteProject(id);
        return NoContent();
    }

    // Add other actions...
}
