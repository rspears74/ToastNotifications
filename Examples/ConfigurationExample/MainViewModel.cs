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
                _notificationService.ChangePosition(_corner, _relation);
            }
        }

        private PositionRelation _relation;
        public PositionRelation Relation
        {
            get { return _relation; }
            set
            {
                _relation = value;
                OnPropertyChanged("Relation");
                _notificationService.ChangePosition(_corner, _relation);
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