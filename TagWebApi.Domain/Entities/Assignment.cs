public class ProjectAssignment
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ProjectId { get; set; }

    public AssignmentRoleType Role { get; set; }

    // Navigation properties
    public virtual User User { get; set; }
    public virtual Project Project { get; set; }
}

public class TaskAssignment
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public int TaskActivityId { get; set; }

    // Navigation properties
    public virtual User User { get; set; }
    public TaskActivity TaskActivity { get; internal set; }
}

public enum AssignmentRoleType
{
    Labeler,
    Reviewer,
    Validator,

    Owner,

    Viewer
}