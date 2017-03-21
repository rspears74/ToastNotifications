using ToastNotifications.Core;

namespace ToastNotifications.Messages.Information
{
    public class InformationNotification : NotificationBase
    {
        private NotificationDisplayPart _displayPart;

        public string Message { get; }
        
        public InformationNotification(string message)
        {
            Message = message;
        }

        public override NotificationDisplayPart DisplayPart => _displayPart ?? (_displayPart = new InformationDisplayPart(this));
    }
}