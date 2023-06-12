using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class MainTasksController : ControllerBase
{
    private readonly IMainTaskRepository _taskRepository;

    public MainTasksController(IMainTaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTasks()
    {
        var tasks = await _taskRepository.GetAllTasks();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        var task = await _taskRepository.GetTaskById(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask(MainTask task)
    {
        await _taskRepository.CreateTask(task);
        return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, MainTask task)
    {
        if (id != task.Id)
        {
            return BadRequest();
        }

        var existingTask = await _taskRepository.GetTaskById(id);
        if (existingTask == null)
        {
            return NotFound();
        }

        await _taskRepository.UpdateTask(task);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _taskRepository.GetTaskById(id);
        if (task == null)
        {
            return NotFound();
        }

        await _taskRepository.DeleteTask(task);
        return NoContent();
    }
}
