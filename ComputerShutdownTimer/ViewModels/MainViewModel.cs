using ComputerShutdownTimer.Models;
using System.Windows.Media.Imaging;

namespace ComputerShutdownTimer.ViewModels
{
    internal class MainViewModel : ViewModelBase<BitmapImage>
    {
        private readonly IconsModel iconsModel = new IconsModel();

        private BitmapImage _appIcon;
        private BitmapImage _settingsIcon;
        private BitmapImage _arrowIcon;
        private BitmapImage _toTrayIcon;
        private BitmapImage _minimizeIcon;
        private BitmapImage _normalizeIcon;
        private BitmapImage _maximizeIcon;
        private BitmapImage _closeIcon;

        public BitmapImage AppIcon
        {
            get => iconsModel.AppIcon;
            set => SetProperty(ref _appIcon, value);
        }

        public BitmapImage SettingsIcon
        {
            get => iconsModel.SettingsIcon;
            set => SetProperty(ref _settingsIcon, value);
        }

        public BitmapImage ArrowIcon
        {
            get => iconsModel.ArrowIcon;
            set => SetProperty(ref _arrowIcon, value);
        }

        public BitmapImage ToTrayIcon
        {
            get => iconsModel.ToTrayIcon;
            set => SetProperty(ref _toTrayIcon, value);
        }

        public BitmapImage MinimizeIcon
        {
            get => iconsModel.MinimizeIcon;
            set => SetProperty(ref _minimizeIcon, value);
        }

        public BitmapImage NormalizeIcon
        {
            get => iconsModel.NormalizeIcon;
            set => SetProperty(ref _normalizeIcon, value);
        }

        public BitmapImage MaximizeIcon
        {
            get => iconsModel.MaximizeIcon;
            set => SetProperty(ref _maximizeIcon, value);
        }

        public BitmapImage CloseIcon
        {
            get => iconsModel.CloseIcon;
            set => SetProperty(ref _closeIcon, value);
        }
    }
}
