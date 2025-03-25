using System.Collections.Concurrent;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BootCampAPI.Application.Notifications;

internal class NotificationBatchManager
{
    // Store a queue of deferred task functions
    private static readonly AsyncLocal<ConcurrentDictionary<Tuple<Type, Type>, ConcurrentQueue<INotification>>> PostTransactionHandlers = new();
    private static readonly AsyncLocal<ConcurrentDictionary<Tuple<Type, Type>, ConcurrentQueue<INotification>>> PreTransactionHandlers = new();
    private static readonly AsyncLocal<IServiceProvider> ServiceProvider = new();

    public static Task DispatchPostTransactionNotifications()
        => DispatchNotifications(PostTransactionHandlers);

    public static Task DispatchPreTransactionNotifications()
        => DispatchNotifications(PreTransactionHandlers);

    public static void EnqueuePostTransactionNotification<T>(Notification<T> notification, INotificationBatchHandler<T> handler)
        => EnqueueNotification(PostTransactionHandlers, notification, handler);

    public static void EnqueuePreTransactionNotification<T>(Notification<T> notification, INotificationBatchHandler<T> handler)
        => EnqueueNotification(PreTransactionHandlers, notification, handler);

    public static void Init(IServiceProvider serviceProvider)
    {
        if (PostTransactionHandlers.Value == null)
            PostTransactionHandlers.Value = new();

        if (PreTransactionHandlers.Value == null)
            PreTransactionHandlers.Value = new();

        ServiceProvider.Value = serviceProvider;
    }

    private static async Task DispatchNotifications(AsyncLocal<ConcurrentDictionary<Tuple<Type, Type>, ConcurrentQueue<INotification>>> queue)
    {
        if (queue?.Value?.Keys?.Any() != true || ServiceProvider.Value is null)
            return;

        List<Task> tasks = new();

        foreach (Tuple<Type, Type> key in queue.Value.Keys)
        {
            // Instantiate the handler
            object handler = ServiceProvider.Value.GetRequiredService(key.Item2);

            if (handler is null)
                continue;

            List<INotification> notifications = new();

            // Get the notifications
            while (!queue.Value[key].IsEmpty)
            {
                if (queue.Value[key].TryDequeue(out INotification? notification) && notification is not null)
                    notifications.Add(notification);
            }

            // dispatch events to the event handler
            Task? task = key.Item2.GetMethod(
                "HandleBatch",
                BindingFlags.Public | BindingFlags.Instance,
                null,
                [typeof(IEnumerable<INotification>)],
                null)?.Invoke(handler, [notifications]) as Task;

            if (task is not null)
                tasks.Add(task);
        }

        await Task.WhenAll(tasks);
    }

    private static void EnqueueNotification<T>(AsyncLocal<ConcurrentDictionary<Tuple<Type, Type>, ConcurrentQueue<INotification>>> queue, Notification<T> notification, INotificationBatchHandler<T> handler)
    {
        Tuple<Type, Type> key = GetKey(notification, handler);

        // Initialize queue if it doesn't exist
        if (queue.Value == null)
            queue.Value = new();

        if (!queue.Value.ContainsKey(key))
            queue.Value.TryAdd(key, new());

        queue.Value[key].Enqueue(notification);
    }

    private static Tuple<Type, Type> GetKey<T>(INotification notification, INotificationBatchHandler<T> handler)
            => (notification.GetType(), typeof(INotificationBatchHandler<T>)).ToTuple();
}