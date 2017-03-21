using System;
using System.Windows;

namespace ToastNotifications.Core
{
    public interface IPositionProvider : IDisposable
    {
        Window ParentWindow { get; }
        Point GetPosition(double notificationPopupWidth, double notificationPopupHeight);
        double GetHeight();
        EjectDirection EjectDirection { get; }
        event EventHandler UpdatePositionRequested;
    }
}