using ToastNotifications.Messages.Success;

namespace ToastNotifications.Messages
{
    public static class SuccessExtensions
    {
        public static void ShowSuccess(this Notifier notifier, string message)
        {
            notifier.Notify<SuccessNotification>(() => new SuccessNotification(message));
        }
    }
}
