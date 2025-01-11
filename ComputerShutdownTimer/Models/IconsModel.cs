using System.Windows.Media.Imaging;

namespace ComputerShutdownTimer.Models
{
    internal class IconsModel
    {
        public BitmapImage AppIcon { get; private set; }
        public BitmapImage SettingsIcon { get; private set; }
        public BitmapImage ArrowIcon { get; private set; }
        public BitmapImage ToTrayIcon { get; private set; }
        public BitmapImage MinimizeIcon { get; private set; }
        public BitmapImage NormalizeIcon { get; private set; }
        public BitmapImage MaximizeIcon { get; private set; }
        public BitmapImage CloseIcon { get; private set; }
    }
}