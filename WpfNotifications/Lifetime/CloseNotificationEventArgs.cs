using WpfNotifications.Core;

namespace WpfNotifications.Lifetime
{
    public class CloseNotificationEventArgs
    {
        public INotification Notification { get; }

        public CloseNotificationEventArgs(INotification notification)
        {
            Notification = notification;
        }
    }
}