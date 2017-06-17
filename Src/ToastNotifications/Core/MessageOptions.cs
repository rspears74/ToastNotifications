using System;

namespace ToastNotifications.Core
{
    public class MessageOptions
    {
        public double? FontSize { get; set; }

        public bool? ShowCloseButton { get; set; }

        public Action<NotificationBase> NotificationClickAction { get; set; }

        public Action<NotificationBase> CloseClickAction { get; set; }

        public object Tag { get; set; }

        public bool FreezeOnMouseEnter { get; set; } = true;
    }
}
