using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using TagWebApi.Domain;

public interface IUserRepository
{
    Task<User> CreateUser(User user);
    Task<int> DeleteUser(int id);
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetUserByEmail(string email);
    Task<User> GetUserById(int id);
    Task<User> UpdateUser(User user);
}

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserById(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> CreateUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUser(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<int> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id) ?? throw new Exception("User not found");
        _context.Users.Remove(user);
        return await _context.SaveChangesAsync();
    }

    public async Task<User> GetUserByEmail(string email)
    {
       return await _context.Users.FindAsync(email);
    }
}
