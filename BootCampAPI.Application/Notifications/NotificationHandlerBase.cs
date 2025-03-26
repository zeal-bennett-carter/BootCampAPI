using System.Reflection;
using BootCampAPI.Application.Notifications.Attributes;
using MediatR;

namespace BootCampAPI.Application.Notifications;

public abstract class NotificationHandlerBase<TNotification> : INotificationHandler<Notification<TNotification>>
{
    public Task Handle(Notification<TNotification> notification, CancellationToken cancellationToken)
    {
        Type handlerType = GetType();
        bool deferNotification = handlerType.GetCustomAttribute<DeferExecutionUntilTransactionIsCompleteAttribute>() is not null;
        bool batchNotification = handlerType.GetCustomAttribute<BatchNotificationsAttribute>() is not null;

        if (deferNotification)
        {
            if (batchNotification && this is INotificationBatchHandler<TNotification> handler)
            {
                NotificationBatchManager.EnqueuePostTransactionNotification(notification, handler);
                return Task.CompletedTask;
            }
            else
            {
                DeferredNotificationsManager.EnqueueDeferredNotification(() => HandleNotification(notification, cancellationToken));
                return Task.CompletedTask;
            }
        }
        else
        {
            if (batchNotification && this is INotificationBatchHandler<TNotification> handler)
            {
                NotificationBatchManager.EnqueuePreTransactionNotification(notification, handler);
                return Task.CompletedTask;
            }

            return HandleNotification(notification, cancellationToken);
        }
    }

    protected virtual Task HandleNotification(Notification<TNotification> notification, CancellationToken cancellationToken)
        => Task.CompletedTask;
}