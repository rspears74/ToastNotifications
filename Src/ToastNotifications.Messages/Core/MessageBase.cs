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
            UpdateDisplayOptions(displayPart, _options);
            return displayPart;
        }

        protected abstract void UpdateDisplayOptions(TDisplayPart displayPart, MessageOptions options);

        protected abstract TDisplayPart CreateDisplayPart();
    }
}