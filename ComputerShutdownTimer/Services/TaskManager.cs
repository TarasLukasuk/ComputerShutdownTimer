using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public sealed class TaskManager : IDisposable
{
    private readonly List<Task> _voidTasks = new List<Task>();
    private readonly List<Task> _genericTasks = new List<Task>();
    private bool _disposed;
    private readonly object _lock = new object();

    public void Add(Task task)
    {
        if (task == null)
        {
            throw new ArgumentNullException(nameof(task));
        }

        lock (_lock)
        {
            _voidTasks.Add(task);
        }
    }

    public void Add<TResult>(Task<TResult> task)
    {
        if (task == null)
        {
            throw new ArgumentNullException(nameof(task));
        }

        lock (_lock)
        {
            _genericTasks.Add(task);
        }
    }

    public async Task WhenAllAsync()
    {
        Task[] tasksToAwait;
        lock (_lock)
        {
            tasksToAwait = _voidTasks.ToArray();
        }

        await Task.WhenAll(tasksToAwait).ConfigureAwait(false);
    }

    public async Task<TResult[]> WhenAllAsync<TResult>()
    {
        Task<TResult>[] tasksToAwait;
        lock (_lock)
        {
            tasksToAwait = _genericTasks.OfType<Task<TResult>>().ToArray();
        }

        return await Task.WhenAll(tasksToAwait).ConfigureAwait(false);
    }

    public async Task WhenAllCompleteAsync()
    {
        Task[] voidTasks;
        Task[] genericTasks;

        lock (_lock)
        {
            voidTasks = _voidTasks.ToArray();
            genericTasks = _genericTasks.ToArray();
        }

        await Task.WhenAll(voidTasks.Concat(genericTasks)).ConfigureAwait(false);
    }

    public int Count
    {
        get
        {
            lock (_lock)
            {
                return _voidTasks.Count + _genericTasks.Count;
            }
        }
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            lock (_lock)
            {
                _voidTasks.Clear();
                _genericTasks.Clear();
            }
            _disposed = true;
        }
    }
}