using System;

namespace ToastNotifications.Core
{
    public abstract class NotificationBase : INotification
    {
        private Action<INotification> _closeAction;

        public abstract NotificationDisplayPart DisplayPart { get; }

        public int Id { get; set; }
        
        public virtual void Bind(Action<INotification> closeAction)
        {
            _closeAction = closeAction;
        }

        public virtual void Close()
        {
            _closeAction.Invoke(this);
        }
    }
}