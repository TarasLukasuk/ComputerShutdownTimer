using ComputerShutdownTimer.Services;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace ComputerShutdownTimer.Commands
{
    internal class NavigateToPageCommand : ICommand
    {
        private readonly Frame _navigationFrame;
        private readonly PageCache _pageCache = new PageCache();

        public event EventHandler CanExecuteChanged;

        public NavigateToPageCommand(Frame navigationFrame)
        {
            _navigationFrame = navigationFrame ?? throw new ArgumentNullException(nameof(navigationFrame));
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (parameter is string targetPageName)
            {
                var page = _pageCache.GetOrCreatePage(targetPageName);
                _navigationFrame.Navigate(page);
            }
        }
    }
}