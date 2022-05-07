using App.DAL.DTO;
using AutoMapper;
using Base.DAL;

namespace App.DAL.EF.Mappers;

public class IdeaRatingMapper : BaseMapper<IdeaRating, App.Domain.IdeaRating>
{
    public IdeaRatingMapper(IMapper mapper) : base(mapper)
    {
    }
}