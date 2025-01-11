using System.ComponentModel;

namespace ComputerShutdownTimer.ViewModels
{
    internal class ViewModelBase<TType> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty(ref TType field, TType newValue)
        {
            if (Equals(field, newValue))
            {
                return false;
            }
            field = newValue;
            OnPropertyChanged(nameof(field));
            return true;
        }
    }
}