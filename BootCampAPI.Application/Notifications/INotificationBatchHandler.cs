using MediatR;

namespace BootCampAPI.Application.Notifications;

public interface INotificationBatchHandler<T>
{
    Task HandleBatch(IEnumerable<INotification> notifications);

    Task HandleBatch(IEnumerable<Notification<T>> notifications);
}