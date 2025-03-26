using BootCampAPI.Domain.DomainEvents;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Domain
{
    public abstract class AggregateRoot<TIdentifier>(TIdentifier id) : Entity
    {
        private readonly List<IDomainEvent> _domainEvents = new();

        /// <summary>
        /// Return all events and clear the underlying events collection.
        /// </summary>
        public ImmutableList<IDomainEvent> PullEvents()
        {
            var domainEvents = _domainEvents.ToImmutableList();
            _domainEvents.Clear();

            return domainEvents;
        }

        protected void PublishEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        //public SomeAction()
        //{
        //    // Validate dtate

        //    // Make Changes

        //    // Publish Event
        //    PublishEvent(SomeDomainEvent.Create(this));
        //}
    }
}
