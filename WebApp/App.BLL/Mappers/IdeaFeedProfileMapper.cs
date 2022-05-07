using AutoMapper;
using Base.DAL;

namespace App.BLL.Mappers;

public class IdeaFeedProfileMapper: BaseMapper<App.BLL.DTO.IdeaFeedProfile, App.DAL.DTO.IdeaFeedProfile>
{
    public IdeaFeedProfileMapper(IMapper mapper) : base(mapper)
    {
    }
}