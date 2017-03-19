using WpfNotifications.Messages.Error;

namespace WpfNotifications.Messages
{
    public static class ErrorExtensions
    {
        public static void ShowError(this Notifier notifier, string message)
        {
            notifier.Notify<ErrorNotification>(() => new ErrorNotification(message));
        }
    }
}
