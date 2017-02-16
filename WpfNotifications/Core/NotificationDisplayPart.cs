using System;
using System.Windows;
using System.Windows.Controls;
using WpfNotifications.Display;

namespace WpfNotifications.Core
{
    public abstract class NotificationDisplayPart : UserControl
    {
        private readonly NotificationAnimator _animator;
        public INotification Notification { get; protected set; }
        
        protected NotificationDisplayPart()
        {
            _animator = new NotificationAnimator(this, TimeSpan.FromMilliseconds(200), TimeSpan.FromMilliseconds(100));

            Margin = new Thickness(1);

            _animator.Setup();
            
            Loaded += OnLoaded;
            MinHeight = 50;
            Height = 50;
        }
        
        public void Bind<TNotification>(TNotification notification) where TNotification : INotification
        {
            Notification = notification;
            DataContext = Notification;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            _animator.PlayShowAnimation();
        }

        public void OnClose()
        {
            _animator.PlayHideAnimation();
        }
    }
}