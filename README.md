# ToastNotifications V2
#### Toast notifications for WPF

ToastNotifications allows to create and display rich notifications in WPF applications.
It's highly configurable with set of builtin options like positions, behaviours, themes and many others.
It's extendable, it gives you possibility to create custom and interactive notifications in simply manner.

[![Build status](https://ci.appveyor.com/api/projects/status/xk2e7g0nxfh5v92q?svg=true)](https://ci.appveyor.com/project/raflop/toastnotifications)  [![Nuget install](https://img.shields.io/badge/nuget-install-green.svg)](https://www.nuget.org/packages/ToastNotifications/) [![LGPL v3 license](https://img.shields.io/badge/license-LGPLV3-blue.svg)](https://github.com/raflop/ToastNotifications/blob/develop-v2/LICENSE)

## Demo

[![demo](https://raw.githubusercontent.com/raflop/ToastNotifications/develop-v2/Media/demo.gif)](https://raw.githubusercontent.com/raflop/ToastNotifications/develop-v2/Media/demo.gif)

## Usage

### 1 Install nuget:
[ToastNotifications](https://www.nuget.org/packages/ToastNotifications/)

[ToastNotifications.Messages](https://www.nuget.org/packages/ToastNotifications.Messages/)

```
Install-Package ToastNotifications
Install-Package ToastNotifications.Messages
```
ToastNotifications contains base mechanism that allows show custom notifications
ToastNotifications.Messages contains basic notifications messages like error, information, warning, success. It's not required in case you want use your own messages.

### 2 Import ToastNotifications theme in App.xaml
```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/ToastNotifications.Messages;component/Themes/Default.xaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

### 3 Create Notifier instance
```csharp
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
/* * */
Notifier notifier = new Notifier(cfg =>
{
    cfg.PositionProvider = new WindowPositionProvider(
        parentWindow: Application.Current.MainWindow,
        corner: Corner.TopRight,
        offsetX: 10,  
        offsetY: 25);

    cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
        notificationLifetime: TimeSpan.FromSeconds(3),
        maximumNotificationCount: MaximumNotificationCount.FromCount(5));

    cfg.Dispatcher = Application.Current.Dispatcher;
});
```

### 4 Use provided messages
```csharp
using ToastNotifications.Messages;
/* * */
notifier.ShowInformation(message);
notifier.ShowSuccess(message);
notifier.ShowWarning(message);
notifier.ShowError(message);
```

## Configuration

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
