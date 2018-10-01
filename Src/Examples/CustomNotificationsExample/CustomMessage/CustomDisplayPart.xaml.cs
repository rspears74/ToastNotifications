using ToastNotifications.Core;

namespace CustomNotificationsExample.CustomMessage
{
    /// <summary>
    /// Interaction logic for CustomDisplayPart.xaml
    /// </summary>
    public partial class CustomDisplayPart : NotificationDisplayPart
    {
        public CustomDisplayPart(CustomNotification customNotification)
        {
            Bind(customNotification);
            InitializeComponent();
        }
    }
}
