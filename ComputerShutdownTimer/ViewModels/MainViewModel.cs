using ComputerShutdownTimer.Commands;
using ComputerShutdownTimer.Models;
using ComputerShutdownTimer.Services;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ComputerShutdownTimer.ViewModels
{
    internal class MainViewModel : ViewModelBase<BitmapImage>
    {
        private BitmapImage _appIcon;
        private BitmapImage _settingsIcon;
        private BitmapImage _arrowIcon;
        private BitmapImage _toTrayIcon;
        private BitmapImage _minimizeIcon;
        private BitmapImage _normalizeIcon;
        private BitmapImage _maximizeIcon;
        private BitmapImage _closeIcon;

        public MainViewModel(Frame frame)
        {
            ShowPageCommand = new ShowPageCommand(frame);
        }

        public async Task LoadIconsAsync()
        {
            Icon icon = new Icon(new IconLoader(), this);
            await icon.InitializeIconsAsync();
        }

        public ICommand ShowPageCommand { get; }

        public BitmapImage AppIcon
        {
            get => _appIcon;
            set => SetProperty(ref _appIcon, value);
        }

        public BitmapImage SettingsIcon
        {
            get => _settingsIcon;
            set => SetProperty(ref _settingsIcon, value);
        }

        public BitmapImage ArrowIcon
        {
            get => _arrowIcon;
            set => SetProperty(ref _arrowIcon, value);
        }

        public BitmapImage ToTrayIcon
        {
            get => _toTrayIcon;
            set => SetProperty(ref _toTrayIcon, value);
        }

        public BitmapImage MinimizeIcon
        {
            get => _minimizeIcon;
            set => SetProperty(ref _minimizeIcon, value);
        }

        public BitmapImage NormalizeIcon
        {
            get => _normalizeIcon;
            set => SetProperty(ref _normalizeIcon, value);
        }

        public BitmapImage MaximizeIcon
        {
            get => _maximizeIcon;
            set => SetProperty(ref _maximizeIcon, value);
        }

        public BitmapImage CloseIcon
        {
            get => _closeIcon;
            set => SetProperty(ref _closeIcon, value);
        }
    }
}
