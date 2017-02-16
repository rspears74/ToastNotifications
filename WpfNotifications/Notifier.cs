using System;
using WpfNotifications.Core;
using WpfNotifications.Display;
using WpfNotifications.Lifetime;

namespace WpfNotifications
{
    public class Notifier : IDisposable
    {
        private readonly object _syncRoot = new object();

        private readonly Action<NotifierConfiguration> _configureAction;
        private NotifierConfiguration _configuration;
        private INotificationsLifeTimeSupervisor _lifeTimeSupervisor;
        private NotificationsDisplaySupervisor _displaySupervisor;

        public Notifier(Action<NotifierConfiguration> configureAction)
        {
            _configureAction = configureAction;
        }

        public void Notify<T>(Func<INotification> createNotificationFunc)
        {
            Configure();
            _lifeTimeSupervisor.PushNotification(createNotificationFunc());
        }

        private void Configure()
        {
            lock (_syncRoot)
            {
                if (_configuration != null)
                    return;

                var cfg = new NotifierConfiguration();
                _configureAction(cfg);
                _configuration = cfg;

                if (cfg.NotificationLifeTime == NotifierConfiguration.NeverEndingNotification)
                    _lifeTimeSupervisor = new BasicNotificationsLifeTimeSupervisor(cfg.MaximumNotificationCount);
                else
                    _lifeTimeSupervisor = new TimeBasedNotificationsLifeTimeSupervisor(cfg.NotificationLifeTime, cfg.MaximumNotificationCount, cfg.Dispatcher);
                
                _displaySupervisor = new NotificationsDisplaySupervisor(cfg.Dispatcher, cfg.PositionProvider, _lifeTimeSupervisor);
            }
        }


        private bool _disposed = false;
        public void Dispose()
        {
            if (_disposed == false)
            {
                _disposed = true;
                _configuration?.PositionProvider?.Dispose();
                _displaySupervisor?.Dispose();

                _lifeTimeSupervisor?.Dispose();
            }
        }
    }
}
