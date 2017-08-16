using System;
using System.Windows;
using System.Windows.Threading;
using ToastNotifications.Core;

namespace ToastNotifications.Display
{
    /// <summary>
    /// Interaction logic for NotificationsWindow.xaml
    /// </summary>
    public partial class NotificationsWindow : Window
    {
        public NotificationsWindow()
        {
            InitializeComponent();

            ShowInTaskbar = false;
            Visibility = Visibility.Hidden;
        }

        public NotificationsWindow(Window owner)
        {
            InitializeComponent();
            Owner = owner;
        }

        public void SetPosition(Point position)
        {
            Left = position.X;
            Top = position.Y;
        }

        public void ShowNotification(NotificationDisplayPart notification)
        {
            NotificationsList.AddNotification(notification);
            RecomputeLayout();
        }

        public void CloseNotification(NotificationDisplayPart notification)
        {
            NotificationsList.RemoveNotification(notification);
            RecomputeLayout();
        }

        private void RecomputeLayout()
        {
            Dispatcher.Invoke(((Action)(() => {; })), DispatcherPriority.Render);
        }

        public void SetEjectDirection(EjectDirection ejectDirection)
        {
            NotificationsList.ShouldReverseItems = ejectDirection == EjectDirection.ToTop;
        }

        public double GetWidth()
        {
            return Width;
        }

        public double GetHeight()
        {
            return Height;
        }

        internal void SetDisplayOptions(DisplayOptions displayOptions)
        {
            Topmost = displayOptions.TopMost;
            NotificationsList.Width = displayOptions.Width;
        }
    }
}
