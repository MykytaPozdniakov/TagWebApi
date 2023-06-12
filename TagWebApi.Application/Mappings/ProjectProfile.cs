using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagWebApi.Application.DTOs;

namespace TagWebApi.Application.Mappings
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectAssignment, ProjectAssignmentDto>();
            CreateMap<ProjectAssignmentDto, ProjectAssignment>();
        }
    }
}
