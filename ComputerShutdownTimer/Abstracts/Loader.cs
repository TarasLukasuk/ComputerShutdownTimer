namespace ComputerShutdownTimer.Abstracts
{
    internal abstract class Loader
    {
        public abstract Task<TReturn> LoadAsync<TReturn,TValue>(TValue value);
    }
}
