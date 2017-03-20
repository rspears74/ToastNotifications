using WpfNotifications.Core;

namespace WpfNotifications.Messages.Error
{
    public class ErrorNotification : NotificationBase
    {
        private NotificationDisplayPart _displayPart;

        public string Message { get; }
        
        public ErrorNotification(string message)
        {
            Message = message;
        }

        public override NotificationDisplayPart DisplayPart => _displayPart ?? (_displayPart = new ErrorDisplayPart(this));
    }
}