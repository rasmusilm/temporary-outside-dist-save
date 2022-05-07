using App.DAL.DTO;
using Base.Contracts.DAL;

namespace App.Contracts.DAL;

public interface ITagRepository : IEntityRepository<Tag>
{
    
}

public interface ITagRepositoryCustom<TEntity>
{
    
}