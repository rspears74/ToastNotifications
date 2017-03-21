using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
using ToastNotifications;
using ToastNotifications.Core;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace ConfigurationExample
{
    public class NotificationService
    {
        private Notifier _notifier;

        public NotificationService()
        {
            _notifier = CreateNotifier(Corner.TopRight, PositionProviderType.Window, NotificationLifetime.Basic);
            Application.Current.MainWindow.Closing += MainWindowOnClosing;
        }

        public Notifier CreateNotifier(Corner corner, PositionProviderType relation, NotificationLifetime lifetime)
        {
            _notifier?.Dispose();
            _notifier = null;

            return new Notifier(cfg =>
            {
                cfg.PositionProvider = CreatePositionProvider(corner, relation);
                cfg.LifetimeSupervisor = CreateLifetimeSupervisor(lifetime);
                cfg.Dispatcher = Dispatcher.CurrentDispatcher;
            });
        }

        private static INotificationsLifetimeSupervisor CreateLifetimeSupervisor(NotificationLifetime lifetime)
        {
            if (lifetime == NotificationLifetime.Basic)
                return new CountBasedLifetimeSupervisor(MaximumNotificationCount.UnlimitedNotifications());

            return new TimeAndCountBasedLifetimeSupervisor(TimeSpan.FromSeconds(3), MaximumNotificationCount.FromCount(5));
        }

        private static IPositionProvider CreatePositionProvider(Corner corner, PositionProviderType relation)
        {
            switch (relation)
            {
                case PositionProviderType.Window:
                    {
                        return new WindowPositionProvider(Application.Current.MainWindow, corner, 10, 40);
                    }
                case PositionProviderType.Screen:
                    {
                        return new PrimaryScreenPositionProvider(corner, 5, 5);
                    }
                case PositionProviderType.Control:
                    {
                        var mainWindow = Application.Current.MainWindow as MainWindow;
                        var trackingElement = mainWindow?.TrackingElement;
                        return new ControlPositionProvider(mainWindow, trackingElement, corner, 5, 5);
                    }
            }

            throw new InvalidEnumArgumentException();
        }

        internal void ShowWarning(string message)
        {
            _notifier.ShowWarning(message);
        }

        internal void ShowSuccess(string message)
        {
            _notifier.ShowSuccess(message);
        }

        public void ShowInformation(string message)
        {
            _notifier.ShowInformation(message);
        }

        public void ShowError(string message)
        {
            _notifier.ShowError(message);
        }

        public void ChangePosition(Corner corner, PositionProviderType relation, NotificationLifetime lifetime)
        {
            _notifier = CreateNotifier(corner, relation, lifetime);
        }

        private void MainWindowOnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            _notifier.Dispose();
        }
    }
}