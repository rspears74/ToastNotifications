using System;
using System.Windows;
using System.Windows.Media;
using WpfNotifications.Core;

namespace WpfNotifications.Position
{
    public class ControlPositionProvider : IPositionProvider
    {
        private readonly FrameworkElement _element;

        public Window ParentWindow { get; }
        public EjectDirection EjectDirection { get; private set; }

        public ControlPositionProvider(Window parentWindow, FrameworkElement element, EjectDirection ejectDirection)
        {
            _element = element;
            EjectDirection = ejectDirection;
            ParentWindow = parentWindow;

            parentWindow.SizeChanged += ParentWindowOnSizeChanged;
            parentWindow.LocationChanged += ParentWindowOnLocationChanged;
        }

        public Point GetPosition(double notificationPopupWidth, double notificationPopupHeight)
        {
            var source = PresentationSource.FromVisual(ParentWindow);
            if (source?.CompositionTarget == null)
                return new Point(0, 0);

            Matrix transform = source.CompositionTarget.TransformFromDevice;
            Point location = transform.Transform(_element.PointToScreen(new Point(0, 0)));

            switch (EjectDirection)
            {
                case EjectDirection.ToBottom:
                    return GetToBottomPosition(location, notificationPopupWidth, notificationPopupHeight);
                case EjectDirection.ToTop:
                    return GetToTopPosition(location, notificationPopupWidth, notificationPopupHeight);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private Point GetToTopPosition(Point location, double notificationPopupWidth, double notificationPopupHeight)
        {
            return new Point(location.X, location.Y - notificationPopupHeight);
        }

        private Point GetToBottomPosition(Point location, double notificationPopupWidth, double notificationPopupHeight)
        {
            return location;
        }

        public double GetHeight()
        {
            return ParentWindow.ActualHeight;
        }

        public void Dispose()
        {
            ParentWindow.LocationChanged -= ParentWindowOnLocationChanged;
            ParentWindow.SizeChanged -= ParentWindowOnSizeChanged;
        }

        protected virtual void RequestUpdatePosition()
        {
            UpdatePositionRequested?.Invoke(this, EventArgs.Empty);
        }

        private void ParentWindowOnLocationChanged(object sender, EventArgs eventArgs)
        {
            RequestUpdatePosition();
        }

        private void ParentWindowOnSizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
        {
            RequestUpdatePosition();
        }

        public event EventHandler UpdatePositionRequested;
    }
}