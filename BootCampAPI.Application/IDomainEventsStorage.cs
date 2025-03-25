using BootCampAPI.Domain.DomainEvents;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application
{
    public interface IDomainEventsStorage
    {
        public void Enqueue(IEnumerable<IDomainEvent> domainEvents);

        public bool TryDequeue([NotNullWhen(true)] out IDomainEvent? domainEvent);
    }
}
