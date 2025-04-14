using ComputerShutdownTimer.Commands;
using ComputerShutdownTimer.Helpers;
using ComputerShutdownTimer.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ComputerShutdownTimer.ViewModels
{
    internal class MainViewModel : ModelBase
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

        private SolidColorBrush _mainBackground;
        private SolidColorBrush _headerAndButtonBackground;
        private SolidColorBrush _textForeground;
        private SolidColorBrush _buttonBorder;
        private SolidColorBrush _hoverBackground;
        private SolidColorBrush _hoverBorder;
        private SolidColorBrush _pressedBackground;
        private SolidColorBrush _pressedBorder;
        private SolidColorBrush _startButtonHoverBackground;

        public MainViewModel(Frame frame)
        {
            ShowPageCommand = new NavigateToPageCommand(frame);
        }

        public async Task InitializeAsync()
        {
            IconService icon = new IconService(new IconLoaderService(), this);

            using (TaskManager taskManager = new TaskManager())
            {
                try
                {
                    taskManager.Add(icon.InitializeIconsAsync());
                }
                catch (Exception)
                {

                    throw;
                }

                await taskManager.WhenAllAsync();
            }
        }

        public ICommand ShowPageCommand { get; }

        public BitmapImage AppIcon
        {
            get => _appIcon;
            private set => SetProperty(ref _appIcon, value, nameof(AppIcon));
        }

        public BitmapImage SettingsIcon
        {
            get => _settingsIcon;
            private set => SetProperty(ref _settingsIcon, value, nameof(SettingsIcon));
        }

        public BitmapImage ArrowIcon
        {
            get => _arrowIcon;
            private set => SetProperty(ref _arrowIcon, value, nameof(ArrowIcon));
        }

        public BitmapImage ToTrayIcon
        {
            get => _toTrayIcon;
            private set => SetProperty(ref _toTrayIcon, value, nameof(ToTrayIcon));
        }

        public BitmapImage MinimizeIcon
        {
            get => _minimizeIcon;
            private set => SetProperty(ref _minimizeIcon, value, nameof(MinimizeIcon));
        }

        public BitmapImage NormalizeIcon
        {
            get => _normalizeIcon;
            private set => SetProperty(ref _normalizeIcon, value, nameof(NormalizeIcon));
        }

        public BitmapImage MaximizeIcon
        {
            get => _maximizeIcon;
            private set => SetProperty(ref _maximizeIcon, value, nameof(MaximizeIcon));
        }

        public BitmapImage CloseIcon
        {
            get => _closeIcon;
            private set => SetProperty(ref _closeIcon, value, nameof(CloseIcon));
        }

        public BitmapImage PlayIcon
        {
            get => _playIcon;
            private set => SetProperty(ref _playIcon, value, nameof(PlayIcon));
        }

        public BitmapImage PauseIcon
        {
            get => _pauseIcon;
            private set => SetProperty(ref _pauseIcon, value, nameof(PauseIcon));
        }

        public SolidColorBrush MainBackground
        {
            get => _mainBackground;
            private set => SetProperty(ref _mainBackground, value, nameof(MainBackground));
        }

        public SolidColorBrush HeaderAndButtonBackground
        {
            get => _headerAndButtonBackground;
            private set => SetProperty(ref _headerAndButtonBackground, value, nameof(HeaderAndButtonBackground));
        }

        public SolidColorBrush TextForeground
        {
            get => _textForeground;
            private set => SetProperty(ref _textForeground, value, nameof(TextForeground));
        }

        public SolidColorBrush ButtonBorder
        {
            get => _buttonBorder;
            private set => SetProperty(ref _buttonBorder, value, nameof(ButtonBorder));
        }

        public SolidColorBrush HoverBackground
        {
            get => _hoverBackground;
            private set => SetProperty(ref _hoverBackground, value, nameof(HoverBackground));
        }

        public SolidColorBrush HoverBorder
        {
            get => _hoverBorder;
            private set => SetProperty(ref _hoverBorder, value, nameof(HoverBorder));
        }

        public SolidColorBrush PressedBackground
        {
            get => _pressedBackground;
            private set => SetProperty(ref _pressedBackground, value, nameof(PressedBackground));
        }

        public SolidColorBrush PressedBorder
        {
            get => _pressedBorder;
            private set => SetProperty(ref _pressedBorder, value, nameof(PressedBorder));
        }

        public SolidColorBrush StartButtonHoverBackground
        {
            get => _startButtonHoverBackground;
            private set => SetProperty(ref _startButtonHoverBackground, value, nameof(StartButtonHoverBackground));
        }

        public void SetPropertyValue<TValue>(string propertyName, TValue value)
        {
            if (Validator.IsValidClassImplementInterface(this))
            {
                base.SetPropertyValue(propertyName, value, this);
            }
        }
    }
}
