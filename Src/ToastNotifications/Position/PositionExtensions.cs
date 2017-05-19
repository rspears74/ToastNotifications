using System.Windows;

namespace ToastNotifications.Position
{
    public static class PositionExtensions
    {
        public static  Point GetActualPosition(this UIElement element)
        {
            return element.PointToScreen(new Point(0, 0));
        }
    }
}