using MediatR;

namespace BootCampAPI.Application.Notifications;

public class Notification<T> : INotification
{
    public Notification(T detail)
    {
        Detail = detail;
    }

    public T Detail { get; }
}