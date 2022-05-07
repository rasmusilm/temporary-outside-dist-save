using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Base;

namespace App.Domain;

public class Complexity : DomainEntityId
{
    [Display( ResourceType = typeof(App.Resourses.App.Domain.Complexity), Name = nameof(App.Resourses.App.Domain.Complexity.Name))]
    [Column(TypeName = "jsonb")]
    public LangStr Name { get; set; } = new ();

    public ICollection<ProjectIdea>? ProjectIdeas { get; set; } = default!;
}