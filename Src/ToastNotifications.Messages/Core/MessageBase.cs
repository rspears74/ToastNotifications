﻿using System.Windows;
using System.Windows.Input;
using ToastNotifications.Core;

namespace ToastNotifications.Messages.Core
{
    public abstract class MessageBase<TDisplayPart> : NotificationBase where TDisplayPart : NotificationDisplayPart
    {
        private NotificationDisplayPart _displayPart;
        
        protected MessageBase(string message, MessageOptions options): base(message, options)
        {
        }

        public override NotificationDisplayPart DisplayPart => _displayPart ?? (_displayPart = Configure());

        private TDisplayPart Configure()
        {
            TDisplayPart displayPart = CreateDisplayPart();

            displayPart.Unloaded += OnUnloaded;
            displayPart.MouseLeftButtonUp += OnLeftMouseUp;

            UpdateDisplayOptions(displayPart, Options);
            return displayPart;
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            _displayPart.MouseLeftButtonUp -= OnLeftMouseUp;
            _displayPart.Unloaded -= OnUnloaded;
        }

        private void OnLeftMouseUp(object sender, MouseButtonEventArgs e)
        {
            Options.NotificationClickAction?.Invoke(this);
            e.Handled = true;
        }

        protected abstract void UpdateDisplayOptions(TDisplayPart displayPart, MessageOptions options);

        protected abstract TDisplayPart CreateDisplayPart();
    }
}