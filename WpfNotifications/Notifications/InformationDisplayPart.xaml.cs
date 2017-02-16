using System.Windows;

namespace WpfNotifications.Notifications
{
    /// <summary>
    /// Interaction logic for InformationDisplayPart.xaml
    /// </summary>
    public partial class InformationDisplayPart
    {
        private readonly Information _viewModel;

        public InformationDisplayPart(Information information)
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
