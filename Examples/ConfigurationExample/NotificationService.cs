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
            _notifier = CreateNotifier(Corner.TopRight, PositionRelation.Window);
            Application.Current.MainWindow.Closing += MainWindowOnClosing;
        }

        private Notifier CreateNotifier(Corner corner, PositionRelation relation)
        {
            _notifier?.Dispose();
            _notifier = null;

            return new Notifier(cfg =>
            {
                IPositionProvider positionProvider = null;
                if (relation == PositionRelation.Window)
                    positionProvider = new WindowPositionProvider(Application.Current.MainWindow, corner, 5, 5);
                else
                    positionProvider = new PrimaryScreenPositionProvider(corner, 5, 5);

                cfg.PositionProvider = positionProvider;
                cfg.Dispatcher = Dispatcher.CurrentDispatcher;
                cfg.NotificationLifeTime = NotifierConfiguration.NeverEndingNotification;
                cfg.MaximumNotificationCount = 5;  //NotifierConfiguration.UnlimitedNotifications;
            });
        }

        public void ChangePosition(Corner corner, PositionRelation relation)
        {
            _notifier = CreateNotifier(corner, relation);
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