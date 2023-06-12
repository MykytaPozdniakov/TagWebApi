namespace TagWebApi.Application.DTOs
{
    public class ProjectAddDto
    {
        public AITaskType AITaskType { get; set; }

        public string Name { get; set; }

        public Project Project { get; set; }

        public AssignmentRoleType Role { get; set; }
    }

    
}
