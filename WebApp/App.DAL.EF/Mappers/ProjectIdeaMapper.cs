using App.DAL.DTO;
using AutoMapper;
using Base.DAL;

namespace App.DAL.EF.Mappers;

public class ProjectIdeaMapper : BaseMapper<ProjectIdea, Domain.ProjectIdea>
{
    public ProjectIdeaMapper(IMapper mapper) : base(mapper)
    {
    }
}