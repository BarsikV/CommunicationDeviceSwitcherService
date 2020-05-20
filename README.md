# CommunicationDeviceSwitcherService
A windows service for switching the default communication device automatically, when the playback device is changed

If you have troubles with the discord audio settings, this might help.

The main reason to create this was a problem with audio settings in discord. Discord gives the option to set the audio output to default or one of your devices. It works very well if you have only one device, or you only use headphones for voice calls. However, if you want to change the audio output device, you need to go to the discord settings and change it there as well. This is so, because windows have a default playback device for app sounds and a default communication device for voice chat, but you can only change the default playback device from tray. So, when you set discord audio to the default it uses the default communication device which cannot be changed from tray. And if you want to alternate between speakers and headphones (or other output devices) every day as you need, this becomes very annoying.

This app saved my day and i thought i could share it with others. It is very simple and it does little to nothing, but it is very helpful to me. When you change your audio output from the windows tray, all the sounds from all the apps, including discord or any other voice chat application will use that audio output device.
