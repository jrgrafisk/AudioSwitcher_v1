# AudioSwitcher

A lightweight Windows system tray utility for instantly switching between audio playback and recording devices — no more digging through Sound Settings.

![Playback Devices](Screenshots/playback.png)

---

## Features

- **Switch audio devices instantly** from the system tray — one click, no menus required
- **Global hotkeys** — assign keyboard shortcuts to individual devices or to cycle through all of them
- **Dual Switch Mode** — set both Default Device and Default Communications Device at the same time
- **Favorite devices** — Quick Switch only cycles between your pinned favorites
- **Hide devices** you never use to keep the list clean
- **Custom device names** — rename any device to something meaningful
- **Force apps to follow** the new default device (Windows 10+)
- **Set startup devices** — automatically restore your preferred devices on login
- **Auto-start with Windows**
- **Update checker** — checks GitHub releases for new versions on startup

### Tray Icon

| Interaction | Behaviour |
|---|---|
| Left click (Quick Switch on) | Cycle to next device |
| Left click (Quick Switch off) | Open device context menu |
| Double click | Show / hide main window |
| Right click | Full context menu with device list |

![Tray](Screenshots/Tray.png)

---

## Screenshots

| Main Window | Settings |
|---|---|
| ![Playback](Screenshots/playback.png) | ![Settings](Screenshots/Settings.png) |

---

## Requirements

- Windows Vista or later (Windows 10+ for "Force Apps Follow Default")
- [.NET 8.0 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/8.0)

---

## Installation

1. Download the latest release from the [Releases page](https://github.com/jrgrafisk/AudioSwitcher_v1/releases/latest)
2. Extract and run `AudioSwitcher.exe`
3. The app starts minimised to the system tray

---

## Building from Source

```bash
git clone https://github.com/jrgrafisk/AudioSwitcher_v1.git
cd AudioSwitcher_v1
dotnet build FortyOne.AudioSwitcher.sln
```

The built executable ends up in `FortyOne.AudioSwitcher/bin/`.

### Dependencies

| Package | Version |
|---|---|
| AudioSwitcher.AudioApi | 4.0.0-alpha5 |
| AudioSwitcher.AudioApi.CoreAudio | 4.0.0-alpha5 |
| fastJSON | 2.1.21 |
| WindowsInput | 0.2.0.0 |

---

## License

[Microsoft Public License (Ms-PL)](LICENSE)
