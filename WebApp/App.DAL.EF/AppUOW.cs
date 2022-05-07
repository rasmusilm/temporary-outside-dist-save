using App.Contracts.DAL;
using App.DAL.DTO;
using App.DAL.EF.Mappers;
using App.DAl.EF.Repositories;
using App.DAL.EF.Repositories;
using Base.DAL.EF;

namespace App.DAL.EF;

public class AppUOW: BaseUOW<ApplicationDbContext>, IAppUnitOfWork
{
    private readonly AutoMapper.IMapper _mapper;
    public AppUOW(ApplicationDbContext dbContext, AutoMapper.IMapper mapper) : base(dbContext)
    {
        _mapper = mapper;
    }

    private IProjectIdeaRepository? _projectIdea;

    public IProjectIdeaRepository ProjectIdeas => 
        _projectIdea ??= new ProjectIdeaRepository(UOWDbContext, new ProjectIdeaMapper(_mapper));
    
    private IIdeaRatingRepository? _ideaRating;

    public IIdeaRatingRepository IdeaRatings => 
        _ideaRating ??= new IdeaRatingRepository(UOWDbContext, new IdeaRatingMapper(_mapper));
    
    private IIdeaFeedProfileRepository? _ideaFeedProfile;

    public IIdeaFeedProfileRepository IdeaFeedProfiles => 
        _ideaFeedProfile ??= new IdeaFeedProfileRepository(UOWDbContext, new  IdeaFeedProfileMapper(_mapper));

    private ITagRepository? _tag;

    public ITagRepository Tags =>
        _tag ??= new TagRepository(UOWDbContext, new TagMapper(_mapper));
}