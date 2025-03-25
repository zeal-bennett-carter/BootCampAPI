using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootCampAPI.Application.Data;
using BootCampAPI.Application.Notifications;
using BootCampAPI.Domain.DomainEvents;
using Microsoft.EntityFrameworkCore.Storage;

namespace BootCampAPI.Application
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatastore _dataStore;
        private readonly IDomainEventDispatcher _dispatcher;
        private readonly IDomainEventsStorage _domainEventsStorage;

        public UnitOfWork(IDatastore dbContext)
        {
            _dataStore = dbContext;
        }

        public async Task Commit()
        {
            // Handle and dispatch collected domain events
            while (_domainEventsStorage.TryDequeue(out IDomainEvent? domainEvent))
                await _dispatcher.Dispatch(domainEvent);

            await _dataStore.SaveChanges();
        }
    }
}
