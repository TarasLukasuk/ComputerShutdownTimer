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
            private set => SetProperty(ref _appIcon, value);
        }

        public BitmapImage SettingsIcon
        {
            get => _settingsIcon;
            private set => SetProperty(ref _settingsIcon, value);
        }

        public BitmapImage ArrowIcon
        {
            get => _arrowIcon;
            private set => SetProperty(ref _arrowIcon, value);
        }

        public BitmapImage ToTrayIcon
        {
            get => _toTrayIcon;
            private set => SetProperty(ref _toTrayIcon, value);
        }

        public BitmapImage MinimizeIcon
        {
            get => _minimizeIcon;
            private set => SetProperty(ref _minimizeIcon, value);
        }

        public BitmapImage NormalizeIcon
        {
            get => _normalizeIcon;
            private set => SetProperty(ref _normalizeIcon, value);
        }

        public BitmapImage MaximizeIcon
        {
            get => _maximizeIcon;
            private set => SetProperty(ref _maximizeIcon, value);
        }

        public BitmapImage CloseIcon
        {
            get => _closeIcon;
            private set => SetProperty(ref _closeIcon, value);
        }

        public BitmapImage PlayIcon
        {
            get => _playIcon;
            private set => SetProperty(ref _playIcon, value);
        }

        public BitmapImage PauseIcon
        {
            get => _pauseIcon;
            private set => SetProperty(ref _pauseIcon, value);
        }

        public SolidColorBrush MainBackground
        {
            get => _mainBackground;
            private set => SetProperty(ref _mainBackground, value);
        }

        public SolidColorBrush HeaderAndButtonBackground
        {
            get => _headerAndButtonBackground;
            private set => SetProperty(ref _headerAndButtonBackground, value);
        }

        public SolidColorBrush TextForeground
        {
            get => _textForeground;
            private set => SetProperty(ref _textForeground, value);
        }

        public SolidColorBrush ButtonBorder
        {
            get => _buttonBorder;
            private set => SetProperty(ref _buttonBorder, value);
        }

        public SolidColorBrush HoverBackground
        {
            get => _hoverBackground;
            private set => SetProperty(ref _hoverBackground, value);
        }

        public SolidColorBrush HoverBorder
        {
            get => _hoverBorder;
            private set => SetProperty(ref _hoverBorder, value);
        }

        public SolidColorBrush PressedBackground
        {
            get => _pressedBackground;
            private set => SetProperty(ref _pressedBackground, value);
        }

        public SolidColorBrush PressedBorder
        {
            get => _pressedBorder;
            private set => SetProperty(ref _pressedBorder, value);
        }

        public SolidColorBrush StartButtonHoverBackground
        {
            get => _startButtonHoverBackground;
            private set => SetProperty(ref _startButtonHoverBackground, value);
        }

        public void SetPoperty(string name) 
        {
            if (string.IsNullOrWhiteSpace(name) && Validator.IsValidClassImplementInterface(this))
            {

            }
        }
    }
}
