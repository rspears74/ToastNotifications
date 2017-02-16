using System.Collections.Concurrent;
using System.Threading;
using WpfNotifications.Core;
using WpfNotifications.Utilities;

namespace WpfNotifications.Lifetime
{
    public class NotificationsList : ConcurrentDictionary<int, NotificationMetaData>
    {
        private int _id = 0;

        public NotificationMetaData Add(INotification notification)
        {
            Interlocked.Increment(ref _id);
            var metaData = new NotificationMetaData(notification, _id, DateTimeNow.Local.TimeOfDay);
            this[_id] = metaData;
            return metaData;
        }
    }
}