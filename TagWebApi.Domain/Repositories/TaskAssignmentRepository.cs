using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using TagWebApi.Domain;

public interface ITaskAssignmentRepository
{
    Task<TaskAssignment> GetAssignmentById(int id);
    Task<IEnumerable<TaskAssignment>> GetAllAssignments();
    Task<TaskAssignment> CreateAssignment(TaskAssignment assignment);
    Task<TaskAssignment> UpdateAssignment(TaskAssignment assignment);
    Task<int> DeleteAssignment(int id);
}

public class TaskAssignmentRepository : ITaskAssignmentRepository
{
    private readonly ApplicationDbContext _context;

    public TaskAssignmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TaskAssignment> GetAssignmentById(int id)
    {
        return await _context.TaskAssignments.FindAsync(id);
    }

    public async Task<IEnumerable<TaskAssignment>> GetAllAssignments()
    {
        return await _context.TaskAssignments.ToListAsync();
    }

    public async Task<TaskAssignment> CreateAssignment(TaskAssignment assignment)
    {
        _context.TaskAssignments.Add(assignment);
        await _context.SaveChangesAsync();
        return assignment;
    }

    public async Task<TaskAssignment> UpdateAssignment(TaskAssignment assignment)
    {
        _context.Entry(assignment).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return assignment;
    }

    public async Task<int> DeleteAssignment(int id)
    {
        var assignment = await _context.TaskAssignments.FindAsync(id);
        if (assignment == null)
        {
            throw new Exception("Assignment not found");
        }

        _context.TaskAssignments.Remove(assignment);
        return await _context.SaveChangesAsync();
    }
}
