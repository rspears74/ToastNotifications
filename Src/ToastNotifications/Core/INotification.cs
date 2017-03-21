using System;

namespace ToastNotifications.Core
{
    public interface INotification
    {
        int Id { get; set; }

        NotificationDisplayPart DisplayPart { get; }

        void Bind(Action<INotification> closeAction);

        void Close();
    }
}