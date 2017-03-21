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
            Dispatcher.Invoke(() => { ; }, DispatcherPriority.Render);
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
    }
}
