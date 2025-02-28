using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ComputerShutdownTimer.Models
{
    internal class IconsModel
    {
        public BitmapImage AppIcon { get; private set; }
        public BitmapImage SettingsIcon { get; private set; }
        public BitmapImage ArrowIcon { get; private set; }
        public BitmapImage ToTrayIcon { get; private set; }
        public BitmapImage MinimizeIcon { get; private set; }
        public BitmapImage NormalizeIcon { get; private set; }
        public BitmapImage MaximizeIcon { get; private set; }
        public BitmapImage CloseIcon { get; private set; }

        private const string BasePath = "Resources\\Images\\";
        private const string FileName = "icons";
        private const string Extension = ".json";

        public async Task InitializeIconsAsync()
        {
            string pathJson = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{BasePath}{FileName}{Extension}").Replace("\\bin\\Debug", string.Empty);

            IconLoader iconLoader = new IconLoader();

            using (FileStream stream = new FileStream(pathJson, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    IconsBase64Model iconsBase64Model = JsonConvert.DeserializeObject<IconsBase64Model>(reader.ReadToEnd());

                    List<Task<BitmapImage>> tasks = new List<Task<BitmapImage>>
                    {
                        iconLoader.LoadIconAsync(iconsBase64Model.App),
                        iconLoader.LoadIconAsync(iconsBase64Model.Setting),
                        iconLoader.LoadIconAsync(iconsBase64Model.Arrow),
                        iconLoader.LoadIconAsync(iconsBase64Model.ToTray),
                        iconLoader.LoadIconAsync(iconsBase64Model.Minimize),
                        iconLoader.LoadIconAsync(iconsBase64Model.Normalize),
                        iconLoader.LoadIconAsync(iconsBase64Model.Maximize),
                        iconLoader.LoadIconAsync(iconsBase64Model.Close)
                    };

                    BitmapImage[] results = await Task.WhenAll(tasks);

                    AppIcon = results[0];
                    SettingsIcon = results[1];
                    ArrowIcon = results[2];
                    ToTrayIcon = results[3];
                    MinimizeIcon = results[4];
                    NormalizeIcon = results[5];
                    MaximizeIcon = results[6];
                    CloseIcon = results[7];
                }
            }
        }
    }
}