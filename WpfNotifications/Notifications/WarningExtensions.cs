namespace WpfNotifications.Notifications
{
    public static class WarningExtensions
    {
        public static void ShowWarning(this Notifier notifier, string message)
        {
            notifier.Notify<Warning>(() => new Warning(message));
        }
    }
}
