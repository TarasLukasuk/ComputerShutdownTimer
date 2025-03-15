using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

internal class IconLoader
{
    public async Task<BitmapImage> LoadIconAsync(string base64String)
    {
        return await Task.Run(() =>
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(imageBytes))
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
}