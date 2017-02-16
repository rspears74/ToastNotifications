using WpfNotifications.Core;

namespace WpfNotifications.Notifications
{
    public class Information : NotificationBase
    {
        private NotificationDisplayPart _displayPart;

        public string Message { get; }
        
        public Information(string message)
        {
            Message = message;
        }

        public override NotificationDisplayPart DisplayPart => _displayPart ?? (_displayPart = new InformationDisplayPart(this));
    }
}