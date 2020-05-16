$params = @{
    Name = "CommunicationAudioAutoSwitchService"
    BinaryPathName = "C:\CommunicationDeviceSwitcherService\CommunicationDeviceSwitcherService.exe"
    DisplayName = "Communication Audio Auto Switch Service"
    StartupType = "Automatic"
    Description = "This service automatically changes default communication output device, when the default playback device is changed"
}

New-Service @params