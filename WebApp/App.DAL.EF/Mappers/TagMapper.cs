using App.DAL.DTO;
using AutoMapper;
using Base.DAL;

namespace App.DAL.EF.Mappers;

public class TagMapper : BaseMapper<Tag, App.Domain.Tag>
{
    public TagMapper(IMapper mapper) : base(mapper)
    {
    }
}