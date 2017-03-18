using WpfNotifications.Core;

namespace WpfNotifications.Notifications
{
    public class Success : NotificationBase
    {
        private NotificationDisplayPart _displayPart;

        public string Message { get; }
        
        public Success(string message)
        {
            Message = message;
        }

        public override NotificationDisplayPart DisplayPart => _displayPart ?? (_displayPart = new SuccessDisplayPart(this));
    }
}