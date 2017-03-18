using System.Windows;
using WpfNotifications.Core;

namespace WpfNotifications.Notifications
{
    /// <summary>
    /// Interaction logic for ErrorDisplayPart.xaml
    /// </summary>
    public partial class ErrorDisplayPart : NotificationDisplayPart
    {
        private readonly Error _viewModel;

        public ErrorDisplayPart(Error error)
        {
            InitializeComponent();

            _viewModel = error;
            DataContext = error;
        }

        private void OnClose(object sender, RoutedEventArgs e)
        {
            _viewModel.Close();
        }
    }
}
