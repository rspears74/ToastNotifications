using System;
using System.Windows;
using WpfNotifications.Core;

namespace WpfNotifications.Position
{
    public class PrimaryScreenPositionProvider : IPositionProvider
    {
        private readonly Corner _corner;
        private readonly double _offsetX;
        private readonly double _offsetY;

        private double ScreenHeight => SystemParameters.PrimaryScreenHeight;
        private double ScreenWidth => SystemParameters.PrimaryScreenWidth;

        public Window ParentWindow { get; }
        public EjectDirection EjectDirection { get; private set; }
        
        public PrimaryScreenPositionProvider(Corner corner, double offsetX, double offsetY)
        {
            _corner = corner;
            _offsetX = offsetX;
            _offsetY = offsetY;
            ParentWindow = null;

            SetEjectDirection(corner);
        }

        public Point GetPosition(double notificationPopupWidth, double notificationPopupHeight)
        {
            switch (_corner)
            {
                case Corner.TopRight:
                    return GetPositionForTopRightCorner(notificationPopupWidth, notificationPopupHeight);
                case Corner.TopLeft:
                    return GetPositionForTopLeftCorner(notificationPopupWidth, notificationPopupHeight);
                case Corner.BottomRight:
                    return GetPositionForBottomRightCorner(notificationPopupWidth, notificationPopupHeight);
                case Corner.BottomLeft:
                    return GetPositionForBottomLeftCorner(notificationPopupWidth, notificationPopupHeight);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public double GetHeight()
        {
            return ScreenHeight;
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

        private Point GetPositionForBottomLeftCorner(double notificationPopupWidth, double notificationPopupHeight)
        {
            return new Point(_offsetX, ScreenHeight - _offsetY - notificationPopupHeight);
        }

        private Point GetPositionForBottomRightCorner(double notificationPopupWidth, double notificationPopupHeight)
        {
            return new Point(ScreenWidth - _offsetX - notificationPopupWidth, ScreenHeight - _offsetY - notificationPopupHeight);
        }

        private Point GetPositionForTopLeftCorner(double notificationPopupWidth, double notificationPopupHeight)
        {
            return new Point(_offsetX, _offsetY);
        }

        private Point GetPositionForTopRightCorner(double notificationPopupWidth, double notificationPopupHeight)
        {
            return new Point(ScreenWidth - _offsetX - notificationPopupWidth, _offsetY);
        }

        public void Dispose()
        {
            // nothing to do here
        }

        // not used in this provider
        public event EventHandler UpdatePositionRequested;
    }
}
