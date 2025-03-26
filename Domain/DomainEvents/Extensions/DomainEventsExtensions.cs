namespace BootCampAPI.Domain.DomainEvents.Extensions;

public static class DomainEventsExtensions
{
    public static IDomainEvent CreateDomainEvent(this Entity entity, Type domainEventGenericType)
    {
        Type concreteType = domainEventGenericType.MakeGenericType(entity.GetType());

        return (IDomainEvent)Activator.CreateInstance(concreteType, [entity])!;
    }
}