using System;
using System.Windows.Threading;

namespace WpfNotifications.Utilities
{
    public interface IInterval
    {
        void Invoke(TimeSpan frequency, Action action, Dispatcher dispatcher);
        void Stop();
    }
}
