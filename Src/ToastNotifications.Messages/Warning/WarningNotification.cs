using ToastNotifications.Core;

namespace ToastNotifications.Messages.Warning
{
    public class WarningNotification : NotificationBase
    {
        private NotificationDisplayPart _displayPart;

        public string Message { get; }
        
        public WarningNotification(string message)
        {
            Message = message;
        }

        public override NotificationDisplayPart DisplayPart => _displayPart ?? (_displayPart = new WarningDisplayPart(this));
    }
}