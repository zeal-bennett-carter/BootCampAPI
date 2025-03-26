namespace BootCampAPI.Domain.DomainEvents;

/// <summary>
///   An event occuring in an <see cref="Entity"/>.
/// </summary>
public interface IDomainEvent
{
    /// <summary>
    ///   The source of the event.
    /// </summary>
    public Entity Source { get; }
}

/// <summary>
///   An event occuring in an <see cref="Entity"/>.
/// </summary>
/// <typeparam name="T">The type of the <see cref="Entity"/> that is the source of the event.</typeparam>
public interface IDomainEvent<T> : IDomainEvent
    where T : Entity
{
    /// <summary>
    ///   The source of the event.
    /// </summary>
    public new T Source { get; }
}