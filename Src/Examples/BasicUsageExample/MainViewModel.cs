using System;
using System.ComponentModel;
using System.Windows;
using WpfNotifications;
using WpfNotifications.Lifetime;
using WpfNotifications.Messages;
using WpfNotifications.Position;

namespace BasicUsageExample
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Notifier _notifier;

        public MainViewModel()
        {
            _notifier = new Notifier(cfg =>
            {
                cfg.PositionProvider = new WindowPositionProvider(
                    parentWindow: Application.Current.MainWindow, 
                    corner: Corner.TopRight, 
                    offsetX: 10,  
                    offsetY: 25);

                cfg.LifetimeSupervisor = new TimeBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(3), 
                    maximumNotificationCount: MaximumNotificationCount.FromCount(5));

                cfg.Dispatcher = Application.Current.Dispatcher;
            });
        }

        public void ShowInformation(string message)
        {
            _notifier.ShowInformation(message);
        }

        public void ShowSuccess(string message)
        {
            _notifier.ShowSuccess(message);
        }

        public void ShowWarning(string message)
        {
            _notifier.ShowWarning(message);
        }

        public void ShowError(string message)
        {
            _notifier.ShowError(message);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}