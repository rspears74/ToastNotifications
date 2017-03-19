using System.Windows.Threading;
using WpfNotifications.Lifetime;

namespace WpfNotifications.Core
{
    public class NotifierConfiguration
    {
        public IPositionProvider PositionProvider { get; set; }
        public INotificationsLifetimeSupervisor LifetimeSupervisor { get; set; }

        public Dispatcher Dispatcher { get; set; }
    }
}