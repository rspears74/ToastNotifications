using System;
using System.Windows;
using ToastNotifications.Core;

namespace ToastNotifications.Position
{
    public class WindowPositionProvider : IPositionProvider
    {
        private readonly Corner _corner;
        private readonly double _offsetX;
        private readonly double _offsetY;

        public Window ParentWindow { get; }
        public EjectDirection EjectDirection { get; private set; }

        public WindowPositionProvider(Window parentWindow, Corner corner, double offsetX, double offsetY)
        {
            _corner = corner;
            _offsetX = offsetX;
            _offsetY = offsetY;
            ParentWindow = parentWindow;

            parentWindow.SizeChanged += ParentWindowOnSizeChanged;
            parentWindow.LocationChanged += ParentWindowOnLocationChanged;

            SetEjectDirection(corner);
        }

        public Point GetPosition(double actualPopupWidth, double actualPopupHeight)
        {
            switch (_corner)
            {
                case Corner.TopRight:
                    return GetPositionForTopRightCorner(actualPopupWidth, actualPopupHeight);
                case Corner.TopLeft:
                    return GetPositionForTopLeftCorner(actualPopupWidth, actualPopupHeight);
                case Corner.BottomRight:
                    return GetPositionForBottomRightCorner(actualPopupWidth, actualPopupHeight);
                case Corner.BottomLeft:
                    return GetPositionForBottomLeftCorner(actualPopupWidth, actualPopupHeight);
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

        private Point GetPositionForBottomLeftCorner(double actualPopupWidth, double actualPopupHeight)
        {
            return new Point(ParentWindow.Left + _offsetX, ParentWindow.Top + ParentWindow.ActualHeight - _offsetY - actualPopupHeight);
        }

        private Point GetPositionForBottomRightCorner(double actualPopupWidth, double actualPopupHeight)
        {
            return new Point(ParentWindow.Left + ParentWindow.ActualWidth - _offsetX - actualPopupWidth, ParentWindow.Top + ParentWindow.ActualHeight - _offsetY - actualPopupHeight);
        }

        private Point GetPositionForTopLeftCorner(double actualPopupWidth, double actualPopupHeight)
        {
            return new Point(ParentWindow.Left + _offsetX, ParentWindow.Top + _offsetY);
        }

        private Point GetPositionForTopRightCorner(double actualPopupWidth, double actualPopupHeight)
        {
            return new Point( ParentWindow.Left + ParentWindow.ActualWidth - _offsetX - actualPopupWidth,  ParentWindow.Top + _offsetY);
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

        public event EventHandler UpdateEjectDirectionRequested;

        public event EventHandler UpdateHeightRequested;
    }
}