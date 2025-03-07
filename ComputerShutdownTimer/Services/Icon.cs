using ComputerShutdownTimer.Models;
using ComputerShutdownTimer.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ComputerShutdownTimer.Services
{
    internal class Icon
    {
        private const string BasePath = "Resources\\";
        private const string FileName = "icons";
        private const string Extension = ".json";

        private readonly IconLoader _iconLoader;
        private readonly MainViewModel _mainViewModel;

        public Icon(IconLoader iconLoader, MainViewModel mainViewModel)
        {
            _iconLoader = iconLoader ?? throw new ArgumentNullException(nameof(iconLoader));
            _mainViewModel = mainViewModel ?? throw new ArgumentNullException(nameof(mainViewModel));
        }

        public async Task InitializeIconsAsync()
        {
            string pathJson = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{BasePath}{FileName}{Extension}").Replace("\\bin\\Debug", string.Empty);

            using (FileStream stream = new FileStream(pathJson, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    IconsBase64Model iconsBase64Model = JsonConvert.DeserializeObject<IconsBase64Model>(reader.ReadToEnd());

                    List<Task<BitmapImage>> tasks = new List<Task<BitmapImage>>
                    {
                        _iconLoader.LoadIconAsync(iconsBase64Model.App),
                        _iconLoader.LoadIconAsync(iconsBase64Model.Arrow),
                        _iconLoader.LoadIconAsync(iconsBase64Model.Close),
                        _iconLoader.LoadIconAsync(iconsBase64Model.Maximize),
                        _iconLoader.LoadIconAsync(iconsBase64Model.Normalize),
                        _iconLoader.LoadIconAsync(iconsBase64Model.Minimize),
                        _iconLoader.LoadIconAsync(iconsBase64Model.Setting),
                        _iconLoader.LoadIconAsync(iconsBase64Model.ToTray)
                    };

                    BitmapImage[] results = await Task.WhenAll(tasks);

                    _mainViewModel.AppIcon = results[0];
                    _mainViewModel.ArrowIcon = results[1];
                    _mainViewModel.CloseIcon = results[2];
                    _mainViewModel.MaximizeIcon = results[3];
                    _mainViewModel.NormalizeIcon = results[4];
                    _mainViewModel.MinimizeIcon = results[5];
                    _mainViewModel.SettingsIcon = results[6];
                    _mainViewModel.ToTrayIcon = results[7];
                }
            }
        }
    }
}
