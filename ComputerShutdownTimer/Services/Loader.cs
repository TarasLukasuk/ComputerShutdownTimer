using System;
using System.Threading.Tasks;

namespace ComputerShutdownTimer.Services
{
    public abstract class Loader<T> : IDisposable
    {
        public abstract void Dispose();

        public abstract Task<T> LoadAsync(string data);
        
    }
}
