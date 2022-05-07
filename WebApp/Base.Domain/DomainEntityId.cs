using Base.Contracts.Domain;

namespace App.Base;

public class DomainEntityId : IDomainEntityId
{
    public Guid Id { get; set; }
}