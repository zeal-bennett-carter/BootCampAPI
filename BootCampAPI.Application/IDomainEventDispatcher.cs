using BootCampAPI.Application.Notifications;
using BootCampAPI.Domain;
using BootCampAPI.Domain.DomainEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(IDomainEvent e);
        Task Dispatch<T>(IDomainEvent<T> domainEvent)
            where T : Entity;
    }
}
