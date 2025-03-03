using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ComputerShutdownTimer.ViewModels
{
    internal class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<TType>(ref TType field, TType newValue, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, newValue))
            {
                return false;
            }
            field = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
