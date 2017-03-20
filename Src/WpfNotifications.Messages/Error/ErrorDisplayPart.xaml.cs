using System.Windows;
using WpfNotifications.Core;

namespace WpfNotifications.Messages.Error
{
    /// <summary>
    /// Interaction logic for ErrorDisplayPart.xaml
    /// </summary>
    public partial class ErrorDisplayPart : NotificationDisplayPart
    {
        private readonly ErrorNotification _viewModel;

        public ErrorDisplayPart(ErrorNotification error)
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
