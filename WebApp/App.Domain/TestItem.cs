using System.ComponentModel.DataAnnotations.Schema;
using App.Base;

namespace App.Domain;

public class TestItem : DomainEntityId
{
    [Column(TypeName = "jsonb")]
    public LangStr Name { get; set; } = new();
}