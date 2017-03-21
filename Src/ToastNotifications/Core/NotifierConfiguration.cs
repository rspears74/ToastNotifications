using System.Windows.Threading;
using ToastNotifications.Lifetime;

namespace ToastNotifications.Core
{
    public class NotifierConfiguration
    {
        public IPositionProvider PositionProvider { get; set; }
        public INotificationsLifetimeSupervisor LifetimeSupervisor { get; set; }

        public Dispatcher Dispatcher { get; set; }
    }
}