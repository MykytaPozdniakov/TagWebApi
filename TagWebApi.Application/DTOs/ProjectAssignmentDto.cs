namespace TagWebApi.Application.DTOs
{
    public class ProjectAssignmentDto
    {
        public int UserId { get; set; }
        public Project Project { get; set; }
        public AssignmentRoleType Role { get; set; }
    }
}
