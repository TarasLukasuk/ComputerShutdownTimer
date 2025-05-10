namespace ComputerShutdownTimer.Services
{
    internal class TaskManager
    {
        private readonly List<Task> _tasks = [];

        private readonly object _lock = new();

        public void Add(Task task)
        {
            lock (_lock)
            {
                _tasks.Add(task);
            }
        }

        public void Add<TValue>(Task<TValue> task)
        {
            lock (_lock)
            {
                _tasks.Add(task);
            }
        }

        public async Task WaitAllTaskAsync()
        {
            try
            {
                await Task.WhenAll(_tasks);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Error while waiting for tasks", ex);
            }
        }

        public void Clear()
        {
            if (_tasks.Count != 0)
            {
                lock (_lock)
                {
                    _tasks.Clear();
                }
            }
        }
    }
}
