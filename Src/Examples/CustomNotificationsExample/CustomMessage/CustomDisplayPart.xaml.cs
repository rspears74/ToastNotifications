using ToastNotifications.Core;

namespace CustomNotificationsExample.CustomMessage
{
    /// <summary>
    /// Interaction logic for CustomDisplayPart.xaml
    /// </summary>
    public partial class CustomDisplayPart : NotificationDisplayPart
    {
        private CustomNotification _customNotification;

        public CustomDisplayPart(CustomNotification customNotification)
        {
            _customNotification = customNotification;
            DataContext = customNotification;
            InitializeComponent();
        }
    }
}
