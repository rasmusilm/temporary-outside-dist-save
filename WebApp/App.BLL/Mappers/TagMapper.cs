using App.BLL.DTO;
using AutoMapper;
using Base.DAL;

namespace App.BLL.Mappers;

public class TagMapper: BaseMapper<Tag, DAL.DTO.Tag>
{
    public TagMapper(IMapper mapper) : base(mapper)
    {
    }
}