using System;
using System.Windows.Threading;

namespace WpfNotifications.Utilities
{
    public class Interval : IInterval
    {
        private DispatcherTimer _timer;

        public void Invoke(TimeSpan frequency, Action action, Dispatcher dispatcher)
        {
            _timer = new DispatcherTimer(frequency, DispatcherPriority.Normal, (sender, args) => action(), dispatcher);
            _timer.Start();
        }

        public void Stop()
        {
            _timer?.Stop();
            _timer = null;
        }
    }
}