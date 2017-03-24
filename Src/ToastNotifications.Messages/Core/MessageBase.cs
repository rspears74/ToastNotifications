using System.Windows;
using System.Windows.Input;
using ToastNotifications.Core;

namespace ToastNotifications.Messages.Core
{
    public abstract class MessageBase<TDisplayPart> : NotificationBase where TDisplayPart : NotificationDisplayPart
    {
        protected NotificationDisplayPart _displayPart;
        private readonly MessageOptions _options;

        public string Message { get; }

        public MessageBase(string message, MessageOptions options)
        {
            Message = message;
            _options = options;
        }

        public override NotificationDisplayPart DisplayPart => _displayPart ?? (_displayPart = Configure());

        private TDisplayPart Configure()
        {
            TDisplayPart displayPart = CreateDisplayPart();

            displayPart.Unloaded += OnUnloaded;
            displayPart.MouseLeftButtonDown += OnLeftMouseDown;

            UpdateDisplayOptions(displayPart, _options);
            return displayPart;
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            _displayPart.MouseLeftButtonDown -= OnLeftMouseDown;
            _displayPart.Unloaded -= OnUnloaded;
        }

        private void OnLeftMouseDown(object sender, MouseButtonEventArgs e)
        {
            _options.NotificationClickAction?.Invoke(this);
        }

        protected abstract void UpdateDisplayOptions(TDisplayPart displayPart, MessageOptions options);

        protected abstract TDisplayPart CreateDisplayPart();
    }
}