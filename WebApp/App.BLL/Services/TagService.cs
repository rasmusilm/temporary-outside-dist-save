using App.BLL.DTO;
using App.Contracts.BLL.Services;
using App.Contracts.DAL;
using Base.BLL;
using Base.Contracts.Base;

namespace App.BLL.Services;

public class TagService : BaseEntityService<Tag, DAL.DTO.Tag, ITagRepository>, ITagService
{
    public TagService(ITagRepository repository, IMapper<Tag, DAL.DTO.Tag> mapper) : base(repository, mapper)
    {
    }
}