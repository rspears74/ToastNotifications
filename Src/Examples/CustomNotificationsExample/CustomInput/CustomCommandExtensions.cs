using System;
using ToastNotifications;

namespace CustomNotificationsExample.CustomInput
{
    public static class CustomInputExtensions
    {
        public static void ShowCustomInput(this Notifier notifier, string message)
        {
            notifier.Notify<CustomInputNotification>(() => new CustomInputNotification(message, message));
        }
    }
}
