using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using TagWebApi.Domain;

public interface IUserCommunicationChannelRepository
{
    Task<UserCommunicationChannel> GetChannelById(int id);
    Task<IEnumerable<UserCommunicationChannel>> GetAllChannels();
    Task<UserCommunicationChannel> CreateChannel(UserCommunicationChannel channel);
    Task<UserCommunicationChannel> UpdateChannel(UserCommunicationChannel channel);
    Task<int>   DeleteChannel(int id);
}

public class UserCommunicationChannelRepository : IUserCommunicationChannelRepository
{
    private readonly ApplicationDbContext _context;

    public UserCommunicationChannelRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserCommunicationChannel> GetChannelById(int id)
    {
        return await _context.UserCommunicationChannels.FindAsync(id);
    }

    public async Task<IEnumerable<UserCommunicationChannel>> GetAllChannels()
    {
        return await _context.UserCommunicationChannels.ToListAsync();
    }

    public async Task<UserCommunicationChannel> CreateChannel(UserCommunicationChannel channel)
    {
        _context.UserCommunicationChannels.Add(channel);
        await _context.SaveChangesAsync();
        return channel;
    }

    public async Task<UserCommunicationChannel> UpdateChannel(UserCommunicationChannel channel)
    {
        _context.Entry(channel).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return channel;
    }

    public async Task<int> DeleteChannel(int id)
    {
        var channel = await _context.UserCommunicationChannels.FindAsync(id);
        if (channel == null)
        {
            throw new Exception("Channel not found");
        }

        _context.UserCommunicationChannels.Remove(channel);
        return await _context.SaveChangesAsync();
    }
}
