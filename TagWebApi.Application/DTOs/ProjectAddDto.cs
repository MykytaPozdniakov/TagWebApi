using System.Collections.Generic;

namespace TagWebApi.Application.DTOs
{
    public class ProjectAddDto
    {
        public AITaskType AITaskType { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<AssignmentDto> Assignments { get; set; }
    }

    public class AssignmentDto
    {
        public AssignmentRoleType AssignmentRoleType { get; set; }

        public string Mail { get; set; }
    }

    public class LabelDto
    {
    
        public LabelType LabelType { get; set; }

        public string Name { get; set; }
    }

    public enum LabelType
    {
        ANY,
        RECTANGLE,
        POLYGON,
        POLYLINE,
        POINTS,
        ELLIPSE,
        CUBOID,
        SKELETON,
        MASK,
        TAG
    }
}
