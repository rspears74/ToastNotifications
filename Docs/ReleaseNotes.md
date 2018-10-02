```
 _______              _   _   _       _   _  __ _           _   _                         ___  
|__   __|            | | | \ | |     | | (_)/ _(_)         | | (_)                       |__ \
   | | ___   __ _ ___| |_|  \| | ___ | |_ _| |_ _  ___ __ _| |_ _  ___  _ __  ___   __   __ ) |
   | |/ _ \ / _` / __| __| . ` |/ _ \| __| |  _| |/ __/ _` | __| |/ _ \| '_ \/ __|  \ \ / // /
   | | (_) | (_| \__ \ |_| |\  | (_) | |_| | | | | (_| (_| | |_| | (_) | | | \__ \   \ V // /_
   |_|\___/ \__,_|___/\__|_| \_|\___/ \__|_|_| |_|\___\__,_|\__|_|\___/|_| |_|___/    \_/|____|

```

# ToastNotifications v2
#### Toast notifications for WPF

## 1.5.0
### New features
Completely new mechanism of clearing selected toast notifications via Notifier instance.
### Bug fixes
ClearMessages(string) does not work #75
### Breaking changes
Changed signature of Notifier.ClearMessages, it takes now as a parameter an instance of IClearStrategy instead of string.
Library provides built in strategies: ClearAll, ClearByMessage, ClearByTag, ClearFirst, ClearLast