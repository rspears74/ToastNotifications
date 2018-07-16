using ToastNotifications.Core;

namespace CustomNotificationsExample.CustomInput
{
    /// <summary>
    /// Interaction logic for CustomCommandDisplayPart.xaml
    /// </summary>
    public partial class CustomInputDisplayPart : NotificationDisplayPart
    {
        private CustomInputNotification _notification;

        public CustomInputDisplayPart(CustomInputNotification notification)
        {
            InitializeComponent();
            _notification = notification;
            DataContext = notification;
        }
    }
}
