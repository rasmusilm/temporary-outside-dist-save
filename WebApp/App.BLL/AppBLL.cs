using App.BLL.Mappers;
using App.BLL.Services;
using App.Contracts.BLL;
using App.Contracts.BLL.Services;
using App.Contracts.DAL;
using AutoMapper;
using Base.BLL;

namespace App.BLL;

public class AppBLL : BaseBll<IAppUnitOfWork>, IAppBLL
{
    protected IAppUnitOfWork UnitOfWork;
    private readonly AutoMapper.IMapper _mapper;

    public AppBLL(IAppUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public override async Task<int> SaveChangesAsync()
    {
        return await UnitOfWork.SaveChangesAsync();
    }

    public override int SaveChanges()
    {
        return UnitOfWork.SaveChanges();
    }

    private IProjectIdeaService? _projectIdeas;
    
    public IProjectIdeaService ProjectIdeas =>
        _projectIdeas ??= new ProjectIdeaService(UnitOfWork.ProjectIdeas, new ProjectIdeaMapper(_mapper));
    
    private IIdeaRatingService? _ideaRatings;
    
    public IIdeaRatingService IdeaRatings =>
        _ideaRatings ??= new IdeaRatingService(UnitOfWork.IdeaRatings, new IdeaRatingMapper(_mapper));
    
    private IIdeaFeedProfileService? _ideaFeedProfiles;
    
    public IIdeaFeedProfileService IdeaFeedProfiles =>
        _ideaFeedProfiles ??= new IdeaFeedService(UnitOfWork.IdeaFeedProfiles, new IdeaFeedProfileMapper(_mapper));

    private ITagService? _tagService;

    public ITagService Tags => _tagService ??= new TagService(UnitOfWork.Tags, new TagMapper(_mapper));
    //
    //
    // private IMeetingOptionService? _meetingOptions;
    //
    // public IMeetingOptionService MeetingOptions =>
    //     _meetingOptions ??= new MeetingOptionService(UnitOfWork.MeetingOptions, new MeetingOptionMapper(_mapper));
}