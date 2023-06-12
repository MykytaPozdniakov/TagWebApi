using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using TagWebApi.Domain;
using static ProjectRepository;
using System.Linq;

public class ProjectRepository: IProjectRepository
{
    private readonly ApplicationDbContext _context;

    public ProjectRepository(ApplicationDbContext context)
    {
        _context = context;
    }    

    public async Task<Project> GetProjectById(int id)
    {
        return await _context.Projects.FindAsync(id);
    }

    public async Task<IEnumerable<Project>> GetAllProjects()
    {
        return await _context.Projects.ToListAsync();
    }

    public async Task<Project> CreateProject(Project project)
    {
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task<Project> UpdateProject(Project project)
    {
        _context.Entry(project).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task<int> DeleteProject(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project == null)
        {
            throw new Exception("Project not found");
        }

        _context.Projects.Remove(project);
        return await _context.SaveChangesAsync();
    }

    public interface IProjectRepository
    {
        Task<Project> GetProjectById(int id);
        Task<IEnumerable<Project>> GetAllProjects();
        Task<Project> CreateProject(Project project);
        Task<Project> UpdateProject(Project project);
        Task<int> DeleteProject(int id);
    }
}
