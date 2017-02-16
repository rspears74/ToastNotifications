using System;
using WpfNotifications.Core;

namespace WpfNotifications.Lifetime
{
    public interface INotificationsLifeTimeSupervisor : IDisposable
    {
        void PushNotification(INotification notification);
        void CloseNotification(INotification notification);
        
        event EventHandler<ShowNotificationEventArgs> ShowNotificationRequested;
        event EventHandler<CloseNotificationEventArgs> CloseNotificationRequested;
    }
}