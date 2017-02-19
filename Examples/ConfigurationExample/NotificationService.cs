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
            _notifier = CreateNotifier(Corner.TopRight, PositionProviderType.Window);
            Application.Current.MainWindow.Closing += MainWindowOnClosing;
        }

        private Notifier CreateNotifier(Corner corner, PositionProviderType relation)
        {
            _notifier?.Dispose();
            _notifier = null;

            return new Notifier(cfg =>
            {
                IPositionProvider positionProvider = null;
                switch (relation)
                {
                    case PositionProviderType.Window:
                        positionProvider = new WindowPositionProvider(Application.Current.MainWindow, corner, 0, 0);
                        break;
                    case PositionProviderType.Screen:
                        positionProvider = new PrimaryScreenPositionProvider(corner, 5, 5);
                        break;
                    case PositionProviderType.Control:
                        var mainWindow = Application.Current.MainWindow as MainWindow;
                        var trackingElement = mainWindow?.TrackingElement;
                        positionProvider = new ControlPositionProvider(mainWindow, trackingElement, corner, 5, 5);
                        break;
                }

                cfg.PositionProvider = positionProvider;
                cfg.Dispatcher = Dispatcher.CurrentDispatcher;
                cfg.NotificationLifeTime = NotifierConfiguration.NeverEndingNotification;
                cfg.MaximumNotificationCount = 5;  //NotifierConfiguration.UnlimitedNotifications;
            });
        }

        public void ChangePosition(Corner corner, PositionProviderType relation)
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