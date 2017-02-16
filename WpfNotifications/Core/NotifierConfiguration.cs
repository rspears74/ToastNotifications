using System;
using System.Windows.Threading;

namespace WpfNotifications.Core
{
    public class NotifierConfiguration
    {
        public IPositionProvider PositionProvider { get; set; }
        public Dispatcher Dispatcher { get; set; }
        public TimeSpan NotificationLifeTime { get; set; }
        public int MaximumNotificationCount { get; set; }
        
        public static readonly int UnlimitedNotifications = int.MaxValue;
        public static readonly TimeSpan NeverEndingNotification  = TimeSpan.MaxValue;
    }
}