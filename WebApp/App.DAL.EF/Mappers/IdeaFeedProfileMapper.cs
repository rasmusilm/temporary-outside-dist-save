using App.DAL.DTO;
using AutoMapper;
using Base.DAL;

namespace App.DAL.EF.Mappers;

public class IdeaFeedProfileMapper : BaseMapper<IdeaFeedProfile, App.Domain.IdeaFeedProfile>
{
    public IdeaFeedProfileMapper(IMapper mapper) : base(mapper)
    {
    }
}