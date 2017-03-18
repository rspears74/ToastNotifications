using WpfNotifications.Core;

namespace WpfNotifications.Notifications
{
    public class Error : NotificationBase
    {
        private NotificationDisplayPart _displayPart;

        public string Message { get; }
        
        public Error(string message)
        {
            Message = message;
        }

        public override NotificationDisplayPart DisplayPart => _displayPart ?? (_displayPart = new ErrorDisplayPart(this));
    }
}