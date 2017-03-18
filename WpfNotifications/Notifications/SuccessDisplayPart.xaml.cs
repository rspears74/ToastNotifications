using System.Windows;
using WpfNotifications.Core;

namespace WpfNotifications.Notifications
{
    /// <summary>
    /// Interaction logic for SuccessDisplayPart.xaml
    /// </summary>
    public partial class SuccessDisplayPart : NotificationDisplayPart
    {
        private readonly Success _viewModel;

        public SuccessDisplayPart(Success success)
        {
            InitializeComponent();

            _viewModel = success;
            DataContext = success;
        }

        private void OnClose(object sender, RoutedEventArgs e)
        {
            _viewModel.Close();
        }
    }
}
