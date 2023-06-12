using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProjectAssignmentsController : ControllerBase
{
    private readonly IProjectAssignmentRepository _projectAssignmentRepository;

    public ProjectAssignmentsController(IProjectAssignmentRepository projectAssignmentRepository)
    {
        _projectAssignmentRepository = projectAssignmentRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProjectAssignments()
    {
        var projectAssignments = await _projectAssignmentRepository.GetAllAssignments();
        return Ok(projectAssignments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProjectAssignmentById(int id)
    {
        var projectAssignment = await _projectAssignmentRepository.GetAssignmentById(id);
        if (projectAssignment == null)
        {
            return NotFound();
        }
        return Ok(projectAssignment);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProjectAssignment(ProjectAssignment projectAssignment)
    {
        await _projectAssignmentRepository.CreateAssignment(projectAssignment);
        return CreatedAtAction(nameof(GetProjectAssignmentById), new { id = projectAssignment.Id }, projectAssignment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProjectAssignment(int id, ProjectAssignment projectAssignment)
    {
        if (id != projectAssignment.Id)
        {
            return BadRequest();
        }

        var existingProjectAssignment = await _projectAssignmentRepository.GetAssignmentById(id);
        if (existingProjectAssignment == null)
        {
            return NotFound();
        }

        await _projectAssignmentRepository.UpdateAssignment(projectAssignment);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProjectAssignment(int id)
    {
        var projectAssignment = await _projectAssignmentRepository.GetAssignmentById(id);
        if (projectAssignment == null)
        {
            return NotFound();
        }

        await _projectAssignmentRepository.DeleteAssignment(id);
        return NoContent();
    }
}
