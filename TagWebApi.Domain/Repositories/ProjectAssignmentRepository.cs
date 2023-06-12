using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using TagWebApi.Domain;
using System.Linq;

public interface IProjectAssignmentRepository
{
    Task<ProjectAssignment> GetAssignmentById(int id);
    Task<IEnumerable<ProjectAssignment>> GetAllAssignments();
    Task<ProjectAssignment> CreateAssignment(ProjectAssignment assignment);
    Task<ProjectAssignment> UpdateAssignment(ProjectAssignment assignment);
    Task<int> DeleteAssignment(int id);
    Task<IEnumerable<ProjectAssignment>> GetAssignmentByUserId(int userId);
}

public class ProjectAssignmentRepository : IProjectAssignmentRepository
{
    private readonly ApplicationDbContext _context;

    public ProjectAssignmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProjectAssignment>> GetAssignmentByUserId(int userId)
    {
        return await _context.ProjectAssignments
            .Where(pa => pa.UserId == userId)
            .ToListAsync();
    }

    public async Task<ProjectAssignment> GetAssignmentById(int id)
    {
        return await _context.ProjectAssignments.FindAsync(id);
    }

    public async Task<IEnumerable<ProjectAssignment>> GetAllAssignments()
    {
        return await _context.ProjectAssignments.ToListAsync();
    }

    public async Task<ProjectAssignment> CreateAssignment(ProjectAssignment assignment)
    {
        _context.ProjectAssignments.Add(assignment);
        await _context.SaveChangesAsync();
        return assignment;
    }

    public async Task<ProjectAssignment> UpdateAssignment(ProjectAssignment assignment)
    {
        _context.Entry(assignment).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return assignment;
    }

    public async Task<int> DeleteAssignment(int id)
    {
        var assignment = await _context.ProjectAssignments.FindAsync(id);
        if (assignment == null)
        {
            throw new Exception("Assignment not found");
        }

        _context.ProjectAssignments.Remove(assignment);
        return await _context.SaveChangesAsync();
    }
}
