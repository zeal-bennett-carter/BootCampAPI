using System.Diagnostics.CodeAnalysis;

namespace BootCampAPI.Domain.DomainEvents;

/// <inheritdoc/>
public class DomainEvent(Entity source) : IDomainEvent
{
    /// <inheritdoc/>
    public virtual Entity Source { get; protected set; } = source;
}

/// <inheritdoc/>
[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Generic Definition")]
public class DomainEvent<T>(T source) : DomainEvent(source), IDomainEvent<T>
    where T : Entity
{
    /// <inheritdoc/>
    public new T Source
    {
        get => (T)base.Source;
        protected set => base.Source = value;
    }
}