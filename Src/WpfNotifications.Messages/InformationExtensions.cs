using WpfNotifications.Messages.Information;

namespace WpfNotifications.Messages
{
    public static class InformationExtensions
    {
        public static void ShowInformation(this Notifier notifier, string message)
        {
            notifier.Notify<InformationNotification>(() => new InformationNotification(message));
        }
    }
}
