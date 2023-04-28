using CommunicationDeviceSwitcherService.Installer.Callback;

try
{
    if (!InstallerCallbackService.IsInstallerCallback(args))
    {
        return;
    }

    await InstallerCallbackService.HandleInstallerCallback(args);
}
catch (Exception e)
{
    await File.WriteAllTextAsync(Path.Combine(AppContext.BaseDirectory, "install_error.txt"), $"{e} \n {e.StackTrace}");
}