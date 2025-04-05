using ComputerShutdownTimer.ViewModels;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ComputerShutdownTimer.Services
{
    class ColorService
    {
        private readonly MainViewModel _mainViewModel;

        public ColorService(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public async Task InitializeColorsAsync()
        {

        }
    }
}
