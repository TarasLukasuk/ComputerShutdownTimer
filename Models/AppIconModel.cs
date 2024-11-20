namespace ComputerShutdownTimer.Models;

class AppIconModel : AbstractModel
{
    public BitmapImage LogoIcon { get; private set; }
    public BitmapImage SettingsIcon { get; private set; }
    public BitmapImage ArrowIcon { get; private set; }
    public BitmapImage TrayIcon { get; private set; }
    public BitmapImage MinimizeIcon { get; private set; }
    public BitmapImage RestoreIcon { get; private set; }
    public BitmapImage MaximizeIcon { get; private set; }
    public BitmapImage CloseIcon { get; private set; }


    public override bool Validate()
    {
        return LogoIcon is not null && SettingsIcon is not null && ArrowIcon is not null && TrayIcon is not null && MinimizeIcon is not null && RestoreIcon is not null && MaximizeIcon is not null && CloseIcon is not null;
    }
}
