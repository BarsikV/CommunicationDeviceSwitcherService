$params = @{
    Name = "CommunicationAudioAutoSwitchService"
    BinaryPathName = "C:\Users\Barsik\source\repos\AudioSwitcherService\AudioSwitcherService\bin\Release\netcoreapp3.1\AudioSwitcherService.exe"
    DisplayName = "Communication Audio Auto Switch Service"
    StartupType = "Automatic"
    Description = "This service automatically changes default communication output device, when the default playback device is changed"
}

New-Service @params