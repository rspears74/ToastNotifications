using System.Windows;
using WpfNotifications.Core;

namespace WpfNotifications.Notifications
{
    /// <summary>
    /// Interaction logic for WarningDisplayPart.xaml
    /// </summary>
    public partial class WarningDisplayPart : NotificationDisplayPart
    {
        private readonly Warning _viewModel;

        public WarningDisplayPart(Warning warning)
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
