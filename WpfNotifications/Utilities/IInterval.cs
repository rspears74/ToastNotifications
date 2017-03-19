using System;
using System.Windows.Threading;

namespace WpfNotifications.Utilities
{
    public interface IInterval
    {
        bool IsRunning { get; }
        void Invoke(TimeSpan frequency, Action action, Dispatcher dispatcher);
        void Stop();
    }
}
