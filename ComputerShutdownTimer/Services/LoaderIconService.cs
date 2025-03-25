using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ComputerShutdownTimer.Services
{
    internal class IconLoaderService : IDisposable
    {
        private bool _disposed;

        public async Task<BitmapImage> LoadIconAsync(string base64String)
        {
            if (string.IsNullOrWhiteSpace(base64String))
            {
                throw new ArgumentNullException(nameof(base64String), "Base64 string cannot be null or empty");
            }

            try
            {
                return await Task.Run(() => LoadIconFromBase64(base64String)).ConfigureAwait(false);
            }
            catch (Exception ex) when (ex is FormatException || ex is ArgumentException)
            {
                throw new FormatException("Invalid base64 image format", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to load icon", ex);
            }
        }

        private static BitmapImage LoadIconFromBase64(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);

            using (MemoryStream memoryStream = new MemoryStream(imageBytes))
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.EndInit();

                if (bitmapImage.CanFreeze)
                {
                    bitmapImage.Freeze();
                }

                return bitmapImage;
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }
    }
}