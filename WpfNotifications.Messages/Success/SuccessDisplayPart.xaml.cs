using System.Windows;
using WpfNotifications.Core;

namespace WpfNotifications.Messages.Success
{
    /// <summary>
    /// Interaction logic for SuccessDisplayPart.xaml
    /// </summary>
    public partial class SuccessDisplayPart : NotificationDisplayPart
    {
        private readonly SuccessNotification _viewModel;

        public SuccessDisplayPart(SuccessNotification success)
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
