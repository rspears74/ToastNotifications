using System;

namespace WpfNotifications.Utilities
{
    public interface IDateTimeProvider
    {
        DateTime GetLocalDateTime();
        DateTime GetUtcDateTime();
    }
}