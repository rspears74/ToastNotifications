using WpfNotifications.Core;

namespace WpfNotifications.Notifications
{
    public class Warning : NotificationBase
    {
        private NotificationDisplayPart _displayPart;

        public string Message { get; }
        
        public Warning(string message)
        {
            Message = message;
        }

        public override NotificationDisplayPart DisplayPart => _displayPart ?? (_displayPart = new WarningDisplayPart(this));
    }
}