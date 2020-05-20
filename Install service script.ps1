param (
    $BinPath = "C:\CommunicationDeviceSwitcherService",
    $Startup = "Automatic",
    $ExeName = "\CommunicationDeviceSwitcherService.exe"
)

$params = @{
    Name = "CommunicationAudioAutoSwitchService"
    BinaryPathName = "$BinPath$ExeName"
    DisplayName = "Communication Audio Auto Switch Service"
    StartupType = "Automatic"
    Description = "This service automatically changes default communication output device, when the default playback device is changed"
}

New-Service @params
Start-Service $params.Name
