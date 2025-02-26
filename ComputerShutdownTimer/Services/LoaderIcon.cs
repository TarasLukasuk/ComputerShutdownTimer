using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

internal class LoaderIcon
{
    private const string BASE_PATH = "Resources\\Images\\";
    private const string EXTENSION = ".png";

    public async Task<BitmapImage> LoadIconAsync(string fileName)
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{BASE_PATH}{fileName}{EXTENSION}").Replace("\\bin\\Debug", string.Empty);

        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"File {path} not found");
        }

        return await Task.Run(() =>
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(path, UriKind.Absolute);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
            bitmap.Freeze();
            return bitmap;
        });
    }
}