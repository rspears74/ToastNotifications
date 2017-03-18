namespace WpfNotifications.Notifications
{
    public static class ErrorExtensions
    {
        public static void ShowError(this Notifier notifier, string message)
        {
            notifier.Notify<Error>(() => new Error(message));
        }
    }
}
