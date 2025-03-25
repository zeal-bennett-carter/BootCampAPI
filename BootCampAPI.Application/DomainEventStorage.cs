using BootCampAPI.Domain.DomainEvents;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application
{
    public class DomainEventStorage: IDomainEventsStorage
    {
        private readonly Queue<IDomainEvent> _domainEvents = new();

        public void Enqueue(IEnumerable<IDomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
                _domainEvents.Enqueue(domainEvent);
        }

        public bool TryDequeue([NotNullWhen(true)] out IDomainEvent? domainEvent) =>
             _domainEvents.TryDequeue(out domainEvent);

    }
}
