# CommunicationDeviceSwitcherService
A windows service for switching the default communication device automatically, when the playback device is changed

If you have troubles with the Discord audio settings, this might help. Discord gives the option to set the audio output to default or one of your devices. It works very well if you have only one device, or you only use headphones for voice calls. However, if you want to change the audio output device, you need to go to the Discord settings and change it there as well. This is because Windows has a default playback device for app sounds and a default communication device for voice chat. However, you can only change the default *playback* device from the system tray. So, when you set Discord audio to the default it uses the default communication device, not the output device you selected from the tray. If you need to alternate between speakers and headphones (or other output devices) throughout the day, this becomes very annoying.

This app saved my day and I thought I could share it with others. It is very simple and it does little to nothing, but it is very helpful to me. When you change your audio output from the windows tray, all the sounds from all the apps, including Discord or any other voice chat application will use that audio output device.

## Installation
See the [releases page](https://github.com/BarsikV/CommunicationDeviceSwitcherService/releases).

## Compiling and Installing from Source
You'll need to download Visual Studio 2019, checkout the repo, and double-click the solution (`.sln` file) in the Solution Explorer (View -> Solution Explorer). Then follow the prompts to install necessary dependencies. You'll need to install .NET (if you don't have the correct version already), then allow NuGet to install missing packages. If the NuGet prompt doesn't show up automatically you can right click on the solution in the Solution Explorer box on the right and click "Restore NuGet Packages". (If that fails you'll need to add the NuGet repository to your Visual Studio, see [here](https://stackoverflow.com/a/69045467)). Finally, press the "ComminicationDeviceSwitcherService" button (green play icon) on the toolbar and it should build and run the debug version.

To install you should do a non-debug build and then run the provided PowerShell script in the root of the project directory with Administrator privileges. If you encounter an error, you'll probably need to set your machine's `ExecutionPolicy` to allow non-signed local scripts, see [here](https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.security/set-executionpolicy?view=powershell-7.2#example-1--set-an-execution-policy). This command needs to be run from an Administrator PowerShell prompt as well.

If you have any questions or problems, please create an issue or send a message on the [Discord channel](https://discord.gg/7kbxzHF).
