using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Base;

namespace App.BLL.DTO;

public class Tag : DomainEntityId
{
    [Display( ResourceType = typeof(App.Resourses.App.Domain.Tag), Name = nameof(Tagname))]
    [Column(TypeName = "jsonb")]
    public LangStr Tagname { get; set; } = new ();
}