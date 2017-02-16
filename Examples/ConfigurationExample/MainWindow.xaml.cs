using System;
using System.Windows;

namespace ConfigurationExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm = new MainViewModel();
        }

        private int _count = 0;
        private readonly MainViewModel _vm;

        private void ShowInternal(NotificationType type, string message)
        {
            message = string.IsNullOrWhiteSpace(message) ? $"{_count++} {type.ToString()}" : message;
            switch (type)
            {
                case NotificationType.Error:
                    _vm.ShowError(message);
                    break;
                case NotificationType.Information:
                    _vm.ShowInformation(message);
                    break;
                case NotificationType.Success:
                    _vm.ShowSuccess(message);
                    break;
                case NotificationType.Warning:
                    _vm.ShowWarning(message);
                    break;
                default:
                    throw new NotImplementedException($"Following notification type isn't supported : {type}");
            }
        }

        private void Button_ShowInformationClick(object sender, RoutedEventArgs e)
        {
            this.ShowInternal(NotificationType.Information, this.SampleTextInput.Text);
        }

        private void Button_ShowSuccessClick(object sender, RoutedEventArgs e)
        {
            this.ShowInternal(NotificationType.Success, this.SampleTextInput.Text);
        }

        private void Button_ShowWarningClick(object sender, RoutedEventArgs e)
        {
            this.ShowInternal(NotificationType.Warning, this.SampleTextInput.Text);
        }

        private void Button_ShowErrorClick(object sender, RoutedEventArgs e)
        {
            this.ShowInternal(NotificationType.Error, this.SampleTextInput.Text);
        }
    }
}
