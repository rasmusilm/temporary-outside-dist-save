using App.Contracts.DAL;
using App.Domain;
using Base.Contracts.Base;
using Base.DAL.EF;

namespace App.DAL.EF.Repositories;

public class TagRepository : BaseEntityRepository<DAL.DTO.Tag, App.Domain.Tag, ApplicationDbContext>, ITagRepository
{
    private ApplicationDbContext _context;
    public TagRepository(ApplicationDbContext dbContext, IMapper<DAL.DTO.Tag, App.Domain.Tag> mapper) : base(dbContext, mapper)
    {
        _context = dbContext;
    }
}