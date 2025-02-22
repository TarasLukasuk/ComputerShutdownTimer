using ComputerShutdownTimer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task InitializationIconsAsync()
        {
            LoaderIcon loaderIcon = new LoaderIcon();

            List<Task<BitmapImage>> tasks = new List<Task<BitmapImage>>
            {
                loaderIcon.LoadIconAsync("app"),
                loaderIcon.LoadIconAsync("settings"),
                loaderIcon.LoadIconAsync("arrow"),
                loaderIcon.LoadIconAsync("to_tray"),
                loaderIcon.LoadIconAsync("minimize"),
                loaderIcon.LoadIconAsync("normalize"),
                loaderIcon.LoadIconAsync("maximize"),
                loaderIcon.LoadIconAsync("close")
            };

            BitmapImage[] results = await Task.WhenAll(tasks);

            AppIcon = results[0];
            SettingsIcon = results[1];
            ArrowIcon = results[2];
            ToTrayIcon = results[3];
            MinimizeIcon = results[4];
            NormalizeIcon = results[5];
            MaximizeIcon = results[6];
            CloseIcon = results[7];
        }
    }
}
