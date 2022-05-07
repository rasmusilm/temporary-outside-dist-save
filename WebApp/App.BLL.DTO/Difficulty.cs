using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Base;

namespace App.BLL.DTO;

public class Difficulty : DomainEntityId
{
    [Display( ResourceType = typeof(App.Resourses.App.Domain.Difficulty), Name = nameof(App.Resourses.App.Domain.Difficulty.Name))]
    [Column(TypeName = "jsonb")]
    public LangStr Name { get; set; } = new ();

    
}