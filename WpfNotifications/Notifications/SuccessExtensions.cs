namespace WpfNotifications.Notifications
{
    public static class SuccessExtensions
    {
        public static void ShowSuccess(this Notifier notifier, string message)
        {
            notifier.Notify<Success>(() => new Success(message));
        }
    }
}
