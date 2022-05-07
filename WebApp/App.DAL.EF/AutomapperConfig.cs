using AutoMapper;

namespace App.DAL.EF;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        CreateMap<App.DAL.DTO.ProjectIdea, App.Domain.ProjectIdea>().ReverseMap();
        CreateMap<App.DAL.DTO.IdeaFeedProfile, App.Domain.IdeaFeedProfile>().ReverseMap();
        CreateMap<App.DAL.DTO.IdeaRating, App.Domain.IdeaRating>().ReverseMap();
        CreateMap<App.DAL.DTO.Identity.User, App.Domain.Identity.User>().ReverseMap();
        CreateMap<App.DAL.DTO.Tag, App.Domain.Tag>().ReverseMap();
        CreateMap<App.DAL.DTO.IdeaTag, App.Domain.IdeaTag>().ReverseMap();
    }
}
