using System.Collections.Generic;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    // Navigation properties
    public ICollection<UserCommunicationChannel> UserCommunicationChannels { get; set; }
    public ICollection<ProjectAssignment> ProjectAssignments { get; set; }
    public ICollection<TaskAssignment> TaskAssignments { get; set; }

    public ICollection<Dispute> Disputes { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}


public class UserCommunicationChannel
{
    public int UserId { get; set; }
    public int ChannelId { get; set; }
    public string Value { get; set; }

    // Navigation properties
    public virtual User User { get; set; }
}

public class UserRole
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    // Navigation properties
    public virtual ICollection<User> Users { get; set; }
}


