using System.ComponentModel;
using WpfNotifications.Position;

namespace ConfigurationExample
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Corner _corner;
        private readonly NotificationService _notificationService;

        public Corner Corner
        {
            get { return _corner; }
            set
            {
                _corner = value;
                OnPropertyChanged("Corner");
                _notificationService.ChangePosition(_corner, _positionProviderType, _lifetime);
            }
        }

        private PositionProviderType _positionProviderType;
        public PositionProviderType PositionProviderType
        {
            get { return _positionProviderType; }
            set
            {
                _positionProviderType = value;
                OnPropertyChanged("PositionProviderType");
                _notificationService.ChangePosition(_corner, _positionProviderType, _lifetime);
            }
        }

        private NotificationLifetime _lifetime;

        public NotificationLifetime Lifetime
        {
            get
            {
                return _lifetime;
            }
            set
            {
                _lifetime = value;
                OnPropertyChanged("Lifetime");
                _notificationService.ChangePosition(_corner, _positionProviderType, _lifetime);
            }
        }

        public MainViewModel()
        {
            _notificationService = new NotificationService();
        }

        public void ShowInformation(string message)
        {
            _notificationService.ShowInformation(message);
        }

        public void ShowSuccess(string message)
        {
        }

        public void ShowWarning(string message)
        {
        }

        public void ShowError(string message)
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}