using System.Windows;
using WpfNotifications.Core;

namespace Tests
{
    public class TestPositionProvider : IPositionProvider
    {
        public Window ParentWindow { get; set; }
    }
}
