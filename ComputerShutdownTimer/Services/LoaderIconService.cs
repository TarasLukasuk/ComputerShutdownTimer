using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ComputerShutdownTimer.Services
{
    internal sealed class IconLoaderService : Loader<BitmapImage>
    {
        private bool _disposed;

        public override async Task<BitmapImage> LoadAsync(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentNullException(nameof(data), "Base64 string cannot be null or empty");
            }

            try
            {
                return await Task.Run(() =>
                {
                    byte[] imageBytes = Convert.FromBase64String(data);
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        BitmapImage bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.StreamSource = ms;
                        bitmapImage.EndInit();
                        bitmapImage.Freeze();
                        return bitmapImage;
                    }
                });
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

        public override void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }
    }
}