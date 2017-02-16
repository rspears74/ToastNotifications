using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
using WpfNotifications;
using WpfNotifications.Core;
using WpfNotifications.Notifications;
using WpfNotifications.Position;

namespace ConfigurationExample
{
    public class NotificationService
    {
        private Notifier _notifier;

        public NotificationService()
        {
            _notifier = CreateNotifier(Corner.TopRight);
            Application.Current.MainWindow.Closing += MainWindowOnClosing;
        }

        private Notifier CreateNotifier(Corner corner)
        {
            _notifier?.Dispose();
            _notifier = null;

            return new Notifier(cfg =>
            {
                cfg.PositionProvider = new PrimaryScreenPositionProvider(corner, 5, 5);
                cfg.Dispatcher = Dispatcher.CurrentDispatcher;
                cfg.NotificationLifeTime = NotifierConfiguration.NeverEndingNotification;
                cfg.MaximumNotificationCount = 5;  //NotifierConfiguration.UnlimitedNotifications;
            });
        }

        public void ChangePosition(Corner corner)
        {
            _notifier = CreateNotifier(corner);
        }

        public void ShowInformation(string message)
        {
            _notifier.Notify<Information>(() => new Information(message));
        }

        private void MainWindowOnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            _notifier.Dispose();
        }
    }
}