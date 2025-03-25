using BootCampAPI.Application.Notifications;
using BootCampAPI.Domain.Models.AuthorContent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampAPI.Application.DomainEventHandlers.Authors.AgeChanged
{
    public class LogMessage: NotificationHandlerBase<AgeChangedDomainEvent>
    {
        protected override Task HandleNotification(Notification<AgeChangedDomainEvent> notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Author's age has been changed to {notification.Detail.Source.Age}");
            return Task.CompletedTask;
        }
    }
}
