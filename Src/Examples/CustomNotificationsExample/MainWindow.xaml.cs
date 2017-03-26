using CustomNotificationsExample.CustomMessage;
using System;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;

namespace CustomNotificationsExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Notifier _notifier;

        public MainWindow()
        {
            InitializeComponent();

            Unloaded += OnUnload;

            _notifier = new Notifier(cfg =>
            {
                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(TimeSpan.FromSeconds(5), MaximumNotificationCount.FromCount(15));
                cfg.PositionProvider = new PrimaryScreenPositionProvider(Corner.BottomRight, 10, 10);
            });
        }

        private void OnUnload(object sender, RoutedEventArgs e)
        {
            _notifier.Dispose();
        }
        
        private void CustomMessage_Click(object sender, RoutedEventArgs e)
        {
            _notifier.ShowCustomMessage("Custom notificaton", "This is custom notification based on user control");
        }

        private void CustomCommand_Click(object sender, RoutedEventArgs e)
        {
            _notifier.ShowCustomCommand("Custom command example",
                confirmAction: n => n.Close(),
                declineAction: n => n.Close());
        }
    }
}
