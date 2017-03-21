using ToastNotifications.Messages.Error;

namespace ToastNotifications.Messages
{
    public static class ErrorExtensions
    {
        public static void ShowError(this Notifier notifier, string message)
        {
            notifier.Notify<ErrorNotification>(() => new ErrorNotification(message));
        }
    }
}
