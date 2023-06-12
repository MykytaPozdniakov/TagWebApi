using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TagWebApi.Domain;

public interface IMainTaskRepository
{
    Task<IEnumerable<MainTask>> GetAllTasks();
    Task<MainTask> GetTaskById(int id);
    Task CreateTask(MainTask task);
    Task UpdateTask(MainTask task);
    Task DeleteTask(MainTask task);
}

public class MainTaskRepository : IMainTaskRepository
{
    private readonly ApplicationDbContext _context;

    public MainTaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MainTask>> GetAllTasks()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<MainTask> GetTaskById(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task CreateTask(MainTask task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTask(MainTask task)
    {
        _context.Entry(task).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTask(MainTask task)
    {
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
    }
}
