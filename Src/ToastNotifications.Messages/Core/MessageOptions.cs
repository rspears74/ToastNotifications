using System;
using ToastNotifications.Core;

namespace ToastNotifications.Messages.Core
{
    public class MessageOptions
    {
        public double? FontSize { get; set; }

        public bool? ShowCloseButton { get; set; }
        public Action<NotificationBase> NotificationClickAction { get; set; }
    }
}
