namespace WpfNotifications.Notifications
{
    public static class InformationExtensions
    {
        public static void ShowInformation(this Notifier notifier, string message)
        {
            notifier.Notify<Information>(() => new Information(message));
        }
    }
}
