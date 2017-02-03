# ToastNotifications
####Toast notifications for WPF with MVVM support.

ToastNotifications allows you to show Success, Information, Warning and Error animated notifications, which will disappear after several seconds.

Feel free to modify and use this code with MIT license.

[![Build status](https://ci.appveyor.com/api/projects/status/xk2e7g0nxfh5v92q?svg=true)](https://ci.appveyor.com/project/raflop/toastnotifications)  [![Nuget install](https://img.shields.io/badge/nuget-install-green.svg)](https://www.nuget.org/packages/ToastNotifications/) [![MIT license](https://img.shields.io/badge/mit-license-blue.svg)](https://github.com/raflop/ToastNotifications/blob/master/LICENSE)

## Demo

[![demo](http://devcrew.pl/github/toastnotifications/demo.gif)](http://devcrew.pl/github/toastnotifications/demo.gif)

## Installation

Install via [Nuget Package ToastNotifications](https://www.nuget.org/packages/ToastNotifications/)

```
Install-Package ToastNotifications
```

## Usage

### XAML

```xml
<!- import namespace -->
xmlns:toast="clr-namespace:ToastNotifications;assembly=ToastNotifications"

<!- add NotificationTray to place in view where notifications should appear
    and bind to NotificationsSource in viewmodel -->
<toast:NotificationTray NotificationsSource="{Binding NotificationSource}"
                        PopupFlowDirection="RightUp"
                        VerticalAlignment="Top"
                        HorizontalAlignment="Right" />
```

### C&#35;

```csharp
// Create viewmodel for window with property of type NotificationsSource.
// NotificationsSource is used to show nofifications in ToastNotifications control

public class MainViewModel : INotifyPropertyChanged
{
    private NotificationsSource _notificationSource;

    public NotificationsSource NotificationSource
    {
        get { return _notificationSource; }
        set
        {
            _notificationSource = value;
            OnPropertyChanged("NotificationSource");
        }
    }

    public MainViewModel()
    {
        NotificationSource = new NotificationsSource();
    }

    public void ShowInformation(string message)
    {
        NotificationSource.Show(message, NotificationType.Information);
    }

    public void ShowSuccess(string message)
    {
        NotificationSource.Show(message, NotificationType.Success);
    }

    public void ShowWarning(string message)
    {
        NotificationSource.Show(message, NotificationType.Warning);
    }

    public void ShowError(string message)
    {
        NotificationSource.Show(message, NotificationType.Error);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName = null)
    {
        var handler = PropertyChanged;
        handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
```

## Configuration

### Flow direction

Set direction in which new notifications will appear. It's relative to notification control position.
Avalaible options are:

* LeftDown  (default)
* RightDown
* LeftUp
* RightUp

```xml
<toast:NotificationTray PopupFlowDirection="LeftDown" />
```

### NotificationSource properties

```csharp
public MainViewModel()
{
    NotificationSource = new NotificationsSource
    {
        MaximumNotificationCount = 4,

        NotificationLifeTime = TimeSpan.FromSeconds(3)
    };
}
```

Set `MaximumNotificationCount = NotificationsSource.UnlimitedNotifications` to allow unlimited number of notifications.

Set `NotificationLifeTime = NotificationsSource.NeverEndingNotification` to make notifications opened until user close them.

### NotificationSource dispatcher

```csharp
    NotificationSource = new NotificationsSource(); // use default Dispatcher.CurrentDispatcher
    NotificationSource = new NotificationsSource(specifiedDispatcher); // use different dispatcher
```



## Additional informations

### Strongly named assembly
Assembly is strongly named using pfx file. Pfx file stored in repository is used only in development and continues build, and it is not used to produce official nuget, the real one is not public.

Development:
```sha1
Public key (hash algorithm: sha1):
002400000480000094000000060200000024000052534131000400000100010003fa196e46deb8
0be6daa22a58b9810c8fe593d239f3cd24a4765b1830538c3d7f98b5386d03e8e2c28def79c571
062c36e65119f656949c1003ffdc2373b05858560e3f94790ad5ab832ac372b76fddb84ca36530
6a9dbebe68cbaa2dc45950a722297fa9aacac3970e9695e1022f5735a2c9a37987f847a86dde47
8d7474dd

Public key token is c8166e8e02d32210
```
Release:
```sha1
Public key (hash algorithm: sha1):
002400000480000094000000060200000024000052534131000400000100010041e364d228daad
36e196e7107c6f462568cafe9b0e625e8afbda5db7725e1cdcca788304083b1a92846b372e002c
06c6f74d9466d93f1fceb6a6b207625a515b3790a9d541edc40b3e2d987ea25cff0e5bb9208046
efc04b7e726d8b56b0d4974071e3db0c1f139888e582c72da6659fbfcf1801fdcdca2449013ae5
d0426dce

Public key token is e89d9d7314a7c797
```

## Contributors

Uwy (https://github.com/Uwy)

Andy Li (https://github.com/oneandy)

BrainCrumbz (https://github.com/BrainCrumbz)

wdcossey (https://github.com/wdcossey)
