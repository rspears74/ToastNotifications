using System;
using WpfNotifications.Core;

namespace WpfNotifications.Lifetime
{
    public class ShowNotificationEventArgs : EventArgs
    {
        public INotification Notification { get; }

        public ShowNotificationEventArgs(INotification notification)
        {
            Notification = notification;
        }
    }
}