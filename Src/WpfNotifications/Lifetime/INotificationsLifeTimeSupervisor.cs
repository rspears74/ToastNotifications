using System;
using System.Windows.Threading;
using WpfNotifications.Core;

namespace WpfNotifications.Lifetime
{
    public interface INotificationsLifetimeSupervisor : IDisposable
    {
        void PushNotification(INotification notification);
        void CloseNotification(INotification notification);

        void UseDispatcher(Dispatcher dispatcher);
        
        event EventHandler<ShowNotificationEventArgs> ShowNotificationRequested;
        event EventHandler<CloseNotificationEventArgs> CloseNotificationRequested;
    }
}