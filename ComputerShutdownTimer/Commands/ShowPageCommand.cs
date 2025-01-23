using ComputerShutdownTimer.Services;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace ComputerShutdownTimer.Commands
{
    internal class ShowPageCommand : ICommand
    {
        private readonly Frame _frame;
        private readonly PageCache _pageCache = new PageCache();

        public ShowPageCommand(Frame frame)
        {
            _frame = frame ?? throw new ArgumentNullException(nameof(frame));
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is string pageName)
            {
                _frame.Navigate(_pageCache.SavePage(pageName));
            }
        }
    }
}
