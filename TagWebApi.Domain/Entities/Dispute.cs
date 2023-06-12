public class Dispute
{
    public int Id { get; set; }
    public int ActivityId { get; set; }
    public int UserId { get; set; }

    public int ParentId { get; set; }
    public string Content { get; set; }
    public DisputeStatus Status { get; set; }


    // Navigation properties
    public Dispute Parent { get; set; }
    public User User { get; set; }
    public TaskActivity Activity { get; set; }
}

public enum DisputeStatus
{
    Active,
    Resolved
}
