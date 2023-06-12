using System.Collections.Generic;

public class MainTask
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Instructions { get; set; }

    //Validator assignment
    public int TaskAssignmentId { get; set; }

    // Navigation properties
    public virtual Project Project { get; set; }

    public virtual TaskAssignment Assignments { get; set; }

    public virtual ICollection<TaskActivity> TaskActivities { get; set; }
}

public enum TaskActivityType
{
    Labeling,
    Review
}

public class TaskActivity
{
    public int Id { get; set; }
    public int TaskId { get; set; }
    public TaskActivityType TaskActivityType { get; set; }
    public int TaskAssignmentId { get; set; }
    public decimal Price { get; set; }

    public bool IsPublic { get; set; }

    // Navigation properties
    public virtual Project Project { get; set; }
    public virtual ICollection<TaskAssignment> Assignments { get; set; }
}