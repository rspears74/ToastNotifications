using System.Windows;
using WpfNotifications.Core;

namespace WpfNotifications.Messages.Information
{
    /// <summary>
    /// Interaction logic for InformationDisplayPart.xaml
    /// </summary>
    public partial class InformationDisplayPart : NotificationDisplayPart
    {
        private readonly InformationNotification _viewModel;

        public InformationDisplayPart(InformationNotification information)
        {
            InitializeComponent();

            _viewModel = information;
            DataContext = information;
        }

        private void OnClose(object sender, RoutedEventArgs e)
        {
            _viewModel.Close();
        }
    }
}
