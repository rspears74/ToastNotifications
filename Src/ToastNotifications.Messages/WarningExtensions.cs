using ToastNotifications.Messages.Warning;

namespace ToastNotifications.Messages
{
    public static class WarningExtensions
    {
        public static void ShowWarning(this Notifier notifier, string message)
        {
            notifier.Notify<WarningNotification>(() => new WarningNotification(message));
        }
    }
}
