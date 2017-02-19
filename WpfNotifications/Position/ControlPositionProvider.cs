using System;
using System.Windows;
using System.Windows.Media;
using WpfNotifications.Core;

namespace WpfNotifications.Position
{
    public class ControlPositionProvider : IPositionProvider
    {
        private readonly double _offsetX;
        private readonly double _offsetY;
        private readonly Corner _corner;
        private readonly FrameworkElement _element;

        public Window ParentWindow { get; }
        public EjectDirection EjectDirection { get; private set; }

        public ControlPositionProvider(Window parentWindow, FrameworkElement trackingElement, Corner corner, double offsetX, double offsetY)
        {
            _corner = corner;
            _offsetX = offsetX;
            _offsetY = offsetY;
            _element = trackingElement;

            ParentWindow = parentWindow;

            parentWindow.SizeChanged += ParentWindowOnSizeChanged;
            parentWindow.LocationChanged += ParentWindowOnLocationChanged;

            SetEjectDirection(corner);
        }

        public Point GetPosition(double notificationPopupWidth, double notificationPopupHeight)
        {
            var source = PresentationSource.FromVisual(ParentWindow);
            if (source?.CompositionTarget == null)
                return new Point(0, 0);

            Matrix transform = source.CompositionTarget.TransformFromDevice;
            Point location = transform.Transform(_element.PointToScreen(new Point(0, 0)));
            
            switch (_corner)
            {
                case Corner.TopRight:
                    return GetPositionForTopRightCorner(location, notificationPopupWidth, notificationPopupHeight);
                case Corner.TopLeft:
                    return GetPositionForTopLeftCorner(location, notificationPopupWidth, notificationPopupHeight);
                case Corner.BottomRight:
                    return GetPositionForBottomRightCorner(location, notificationPopupWidth, notificationPopupHeight);
                case Corner.BottomLeft:
                    return GetPositionForBottomLeftCorner(location, notificationPopupWidth, notificationPopupHeight);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public double GetHeight()
        {
            return ParentWindow.ActualHeight;
        }

        private void SetEjectDirection(Corner corner)
        {
            switch (corner)
            {
                case Corner.TopRight:
                case Corner.TopLeft:
                    EjectDirection = EjectDirection.ToBottom;
                    break;
                case Corner.BottomRight:
                case Corner.BottomLeft:
                    EjectDirection = EjectDirection.ToTop;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(corner), corner, null);
            }
        }

        private Point GetPositionForBottomLeftCorner(Point location, double notificationPopupWidth, double notificationPopupHeight)
        {
            return new Point(location.X + _offsetX, location.Y + _element.ActualHeight - _offsetY - notificationPopupHeight);
        }

        private Point GetPositionForBottomRightCorner(Point location, double notificationPopupWidth, double notificationPopupHeight)
        {
            return new Point(location.X + _element.ActualWidth - _offsetX - notificationPopupWidth, location.Y + _element.ActualHeight - _offsetY - notificationPopupHeight);
        }

        private Point GetPositionForTopLeftCorner(Point location, double notificationPopupWidth, double notificationPopupHeight)
        {
            return new Point(location.X + _offsetX, location.Y + _offsetY);
        }

        private Point GetPositionForTopRightCorner(Point location, double notificationPopupWidth, double notificationPopupHeight)
        {
            return new Point(location.X + _element.ActualWidth - _offsetX - notificationPopupWidth, location.Y + _offsetY);
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