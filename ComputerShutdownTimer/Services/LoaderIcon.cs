using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ComputerShutdownTimer.Services
{
    internal class LoaderIcon
    {
        private const string BASE_PATH = "Resources/Images/";
        private const string EXTENSION = ".png";

        public async Task<BitmapImage> LoadIconAsync(string fileName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{BASE_PATH}{fileName}{EXTENSION}");

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"File {path} not found");
            }


            return await Task.Run(() =>
            {
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync: true))
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = stream;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    bitmap.Freeze();
                    return bitmap;
                }
            });
        }
    }
}
