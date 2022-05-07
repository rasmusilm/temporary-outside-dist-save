using AutoMapper;
using Base.DAL;

namespace App.BLL.Mappers;

public class ProjectIdeaMapper: BaseMapper<App.BLL.DTO.ProjectIdea, App.DAL.DTO.ProjectIdea>
{
    public ProjectIdeaMapper(IMapper mapper) : base(mapper)
    {
    }
}