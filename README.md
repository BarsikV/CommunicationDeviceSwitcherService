# CommunicationDeviceSwitcherService
A windows service for switching the default communication device automatically, when the playback device is changed. 
With this you can set the sound settings of Discord and other voice chat applications to default. Then you can switch the output device from tray.
Also work for microphones.

## Installation
See the [releases page](https://github.com/BarsikV/CommunicationDeviceSwitcherService/releases).

## Story and purpose of the app
If you have troubles with the Discord audio settings, this might help. Discord gives the option to set the audio output to default or one of your devices. It works very well if you have only one device, or you only use headphones for voice calls. However, if you want to change the audio output device, you need to go to the Discord settings and change it there as well. This is because Windows has a default playback device for app sounds and a default communication device for voice chat. However, you can only change the default *playback* device from the system tray. So, when you set Discord audio to the default it uses the default communication device, not the output device you selected from the tray. If you need to alternate between speakers and headphones (or other output devices) throughout the day, this becomes very annoying.

This app saved my day and I thought I could share it with others. It is very simple and it does little to nothing, but it is very helpful to me. When you change your audio output from the windows tray, all the sounds from all the apps, including Discord or any other voice chat application will use that audio output device.

## Compiling and Installing from Source
You'll need to download Visual Studio, checkout the repo, and double-click the solution (`.sln` file) in the Solution Explorer (View -> Solution Explorer). Then follow the prompts to install necessary dependencies. You'll need to install .NET (if you don't have the correct version already), then allow NuGet to install missing packages. If the NuGet prompt doesn't show up automatically you can right click on the solution in the Solution Explorer box on the right and click "Restore NuGet Packages". (If that fails you'll need to add the NuGet repository to your Visual Studio, see [here](https://stackoverflow.com/a/69045467)). Finally, press the "CommunicationDeviceSwitcherService" button (green play icon) on the toolbar and it should build and run the debug version.

To install, set the solution configuration to "Release", then rebuild the solution. Right click on the CommunicationDeviceSwitcherService.Installer project and select "Rebuild". Right click again and select "Open Folder in File explorer". Go to the Release folder and run CommunicationDeviceSwitcherService.Installer.

If you have any questions or problems, please create an issue or send a message on the [Discord channel](https://discord.gg/7kbxzHF).
