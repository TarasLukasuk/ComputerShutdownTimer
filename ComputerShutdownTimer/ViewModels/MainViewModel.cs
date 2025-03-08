using ComputerShutdownTimer.Commands;
using ComputerShutdownTimer.Services;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ComputerShutdownTimer.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private BitmapImage _appIcon;
        private BitmapImage _settingsIcon;
        private BitmapImage _arrowIcon;
        private BitmapImage _toTrayIcon;
        private BitmapImage _minimizeIcon;
        private BitmapImage _normalizeIcon;
        private BitmapImage _maximizeIcon;
        private BitmapImage _closeIcon;
        private BitmapImage _playIcon;
        private BitmapImage _pauseIcon;

        private Brush _backgroundColor;
        private Brush _secondaryBackgroundColor;
        private Brush _accentColor;
        private Brush _lightAccentColor;
        private Brush _textColor;
        private Brush _borderColor;
        private Brush _darkBackgroundColor;

        public MainViewModel(Frame frame)
        {
            ShowPageCommand = new ShowPageCommand(frame);
        }

        public async Task InitializeAsync()
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

        public BitmapImage PlayIcon
        {
            get => _playIcon;
            set => SetProperty(ref _playIcon, value);
        }

        public BitmapImage PauseIcon
        {
            get => _pauseIcon;
            set => SetProperty(ref _pauseIcon, value);
        }

        public Brush BackgroundColor
        {
            get => _backgroundColor;
            set => SetProperty(ref _backgroundColor, value);
        }

        public Brush SecondaryBackgroundColor
        {
            get => _secondaryBackgroundColor;
            set => SetProperty(ref _secondaryBackgroundColor, value);
        }

        public Brush AccentColor
        {
            get => _accentColor; 
            set => SetProperty(ref _accentColor, value);
        }

        public Brush LightAccentColor
        {
            get => _lightAccentColor; 
            set => SetProperty(ref _lightAccentColor, value);
        }

        public Brush TextColor
        {
            get => _textColor; 
            set => SetProperty(ref _textColor, value);
        }

        public Brush BorderColor
        {
            get => _borderColor; 
            set => SetProperty(ref _borderColor, value);
        }

        public Brush DarkBackgroundColor
        {
            get => _darkBackgroundColor; 
            set => SetProperty(ref _darkBackgroundColor, value);
        }
    }
}
