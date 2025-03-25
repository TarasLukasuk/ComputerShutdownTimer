using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Tasker
{
    private readonly List<Task> _voidTasks = new List<Task>();
    private readonly List<object> _valueTasks = new List<object>();

    public void AddTask(Task task)
    {
        _voidTasks.Add(task);
    }

    public void AddTask<T>(Task<T> task)
    {
        _valueTasks.Add(task);
    }

    public async Task WaitAllAsync()
    {
        List<Task> allTasks = new List<Task>();
        allTasks.AddRange(_voidTasks);
        await Task.WhenAll(allTasks);
    }

    public async Task<T[]> WaitAllAsync<T>()
    {
        List<Task<T>> tasks = _valueTasks.Cast<Task<T>>().ToList();
        return await Task.WhenAll(tasks);
    }
}