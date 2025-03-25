using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ComputerShutdownTimer.ViewModels
{
    public abstract class ModelBase : INotifyPropertyChanged, IDisposable
    {
        private readonly Dictionary<string, object> _propertyStorage = new Dictionary<string, object>();
        private bool _disposed;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
                return false;

            field = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected T GetProperty<T>(T defaultValue = default, [CallerMemberName] string propertyName = null)
        {
            if (_propertyStorage.TryGetValue(propertyName, out object value))
            {
                return (T)value;
            }
            return defaultValue;
        }

        protected bool SetProperty<T>(T newValue, [CallerMemberName] string propertyName = null)
        {
            T currentValue = GetProperty<T>(propertyName: propertyName);

            if (EqualityComparer<T>.Default.Equals(currentValue, newValue))
            {
                return false;
            }

            _propertyStorage[propertyName] = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertiesChanged(params string[] propertyNames)
        {
            foreach (var name in propertyNames)
            {
                OnPropertyChanged(name);
            }
        }

        protected void ClearProperties()
        {
            var propertyNames = _propertyStorage.Keys.ToList();
            _propertyStorage.Clear();

            foreach (var name in propertyNames)
            {
                OnPropertyChanged(name);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    ClearProperties();
                    PropertyChanged = null;
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}