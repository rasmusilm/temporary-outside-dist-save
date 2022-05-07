using AutoMapper;
using Base.DAL;

namespace App.BLL.Mappers;

public class IdeaRatingMapper : BaseMapper<App.BLL.DTO.IdeaRating, App.DAL.DTO.IdeaRating>
{
    public IdeaRatingMapper(IMapper mapper) : base(mapper)
    {
    }
}