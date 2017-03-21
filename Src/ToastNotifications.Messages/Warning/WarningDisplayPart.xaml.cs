using System.Windows;
using ToastNotifications.Core;

namespace ToastNotifications.Messages.Warning
{
    /// <summary>
    /// Interaction logic for WarningDisplayPart.xaml
    /// </summary>
    public partial class WarningDisplayPart : NotificationDisplayPart
    {
        private readonly WarningNotification _viewModel;

        public WarningDisplayPart(WarningNotification warning)
        {
            InitializeComponent();

            _viewModel = warning;
            DataContext = warning;
        }

        private void OnClose(object sender, RoutedEventArgs e)
        {
            _viewModel.Close();
        }
    }
}
