using App.BLL.DTO;
using AutoMapper;

namespace App.BLL;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        CreateMap<App.BLL.DTO.ProjectIdea, App.DAL.DTO.ProjectIdea>().ReverseMap();
        CreateMap<App.BLL.DTO.IdeaFeedProfile, App.DAL.DTO.IdeaFeedProfile>().ReverseMap();
        CreateMap<App.BLL.DTO.IdeaRating, App.DAL.DTO.IdeaRating>().ReverseMap();
        CreateMap<App.BLL.DTO.Identity.User, App.DAL.DTO.Identity.User>().ReverseMap();
        CreateMap<Tag, DAL.DTO.Tag>().ReverseMap();
        CreateMap<IdeaTag, DAL.DTO.IdeaTag>().ReverseMap();
    }
}
