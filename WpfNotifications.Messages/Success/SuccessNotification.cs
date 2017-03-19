using WpfNotifications.Core;

namespace WpfNotifications.Messages.Success
{
    public class SuccessNotification : NotificationBase
    {
        private NotificationDisplayPart _displayPart;

        public string Message { get; }
        
        public SuccessNotification(string message)
        {
            Message = message;
        }

        public override NotificationDisplayPart DisplayPart => _displayPart ?? (_displayPart = new SuccessDisplayPart(this));
    }
}