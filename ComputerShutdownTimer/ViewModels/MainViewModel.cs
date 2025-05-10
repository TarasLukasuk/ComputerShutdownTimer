using ComputerShutdownTimer.Interfaces;
using ComputerShutdownTimer.Services;

namespace ComputerShutdownTimer.ViewModels
{
    class MainViewModel : IInitialization
    {
        public async Task InitializationAsync()
        {
            TaskManager taskManager = new();
            taskManager.Add();
            taskManager.Add();

            await taskManager.WaitAllTaskAsync();

        }
    }
}
