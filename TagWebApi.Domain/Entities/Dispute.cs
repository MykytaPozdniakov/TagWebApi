using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class DisputeRoot
{
    public int Id { get; set; }
    public int ActivityId { get; set; }
    public int UserId { get; set; }    
    public string Content { get; set; }
    public DisputeStatus Status { get; set; }

    public DateTime DateTime { get; set; }

    // Navigation properties
    public virtual ICollection<DisputeElement> DisputeElements { get; set; }
    public User User { get; set; }
    public TaskActivity Activity { get; set; }
}

public class DisputeElement
{
    public int Id { get; set; }   

    public int DisputeRootId { get; set; }

    public int UserId { get; set; }    

    public string Content { get; set; }

    public DateTime DateTime { get; set; }

    // Navigation properties
    public DisputeRoot DisputeRoot { get; set; }
    public User User { get; set; }
}

public enum DisputeStatus
{
    Active,
    Resolved
}
