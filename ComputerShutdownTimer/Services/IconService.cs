﻿using ComputerShutdownTimer.Models;
using ComputerShutdownTimer.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ComputerShutdownTimer.Services
{
    internal class IconService
    {
        private const string IconResourcesPath = "Resources\\Icons.json";

        private readonly Loader<BitmapImage> _loader;
        private readonly MainViewModel _mainViewModel;

        public IconService(Loader<BitmapImage> loader, MainViewModel mainViewModel)
        {
            _loader = loader ?? throw new ArgumentNullException(nameof(loader));
            _mainViewModel = mainViewModel ?? throw new ArgumentNullException(nameof(mainViewModel));
        }

        public async Task InitializeIconsAsync()
        {
            try
            {
                IconsBase64Model iconsBase64Model = await LoadIconDataAsync();
                await LoadAndAssignIconsAsync(iconsBase64Model);
            }
            catch (Exception ex) when (ex is FileNotFoundException || ex is JsonException || ex is KeyNotFoundException)
            {
                throw new InvalidOperationException("Failed to initialize application icons", ex);
            }
        }

        private async Task<IconsBase64Model> LoadIconDataAsync()
        {
            string filePath = GetIconConfigPath();

            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string jsonContent = await reader.ReadToEndAsync();
                    IconsBase64Model model = JsonConvert.DeserializeObject<IconsBase64Model>(jsonContent);

                    return model;
                }
            }
        }

        private string GetIconConfigPath()
        {
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", string.Empty).Replace("\\bin\\Release", string.Empty),IconResourcesPath);

            if (!File.Exists(basePath))
            {
                throw new FileNotFoundException("Icon configuration file not found", basePath);
            }

            return basePath;
        }

        private async Task LoadAndAssignIconsAsync(IconsBase64Model iconsBase64Model)
        {
            using (TaskManager taskManager = new TaskManager())
            {
                using (_loader)
                {
                    taskManager.Add(_loader.LoadAsync(iconsBase64Model.App));
                    taskManager.Add(_loader.LoadAsync(iconsBase64Model.Arrow));
                    taskManager.Add(_loader.LoadAsync(iconsBase64Model.Close));
                    taskManager.Add(_loader.LoadAsync(iconsBase64Model.Maximize));
                    taskManager.Add(_loader.LoadAsync(iconsBase64Model.Normalize));
                    taskManager.Add(_loader.LoadAsync(iconsBase64Model.Minimize));
                    taskManager.Add(_loader.LoadAsync(iconsBase64Model.Setting));
                    taskManager.Add(_loader.LoadAsync(iconsBase64Model.ToTray));
                    taskManager.Add(_loader.LoadAsync(iconsBase64Model.Play));
                    taskManager.Add(_loader.LoadAsync(iconsBase64Model.Pause));
                }

                AssignIconsToViewModel(await taskManager.WhenAllAsync<BitmapImage>());
            }
        }

        private void AssignIconsToViewModel(BitmapImage[] icons)
        {
            _mainViewModel.SetPropertyValue(nameof(_mainViewModel.AppIcon), icons[0]);
            _mainViewModel.SetPropertyValue(nameof(_mainViewModel.ArrowIcon), icons[1]);
            _mainViewModel.SetPropertyValue(nameof(_mainViewModel.CloseIcon), icons[2]);
            _mainViewModel.SetPropertyValue(nameof(_mainViewModel.MaximizeIcon), icons[3]);
            _mainViewModel.SetPropertyValue(nameof(_mainViewModel.NormalizeIcon), icons[4]);
            _mainViewModel.SetPropertyValue(nameof(_mainViewModel.MinimizeIcon), icons[5]);
            _mainViewModel.SetPropertyValue(nameof(_mainViewModel.SettingsIcon), icons[6]);
            _mainViewModel.SetPropertyValue(nameof(_mainViewModel.ToTrayIcon), icons[7]);
            _mainViewModel.SetPropertyValue(nameof(_mainViewModel.PlayIcon), icons[8]);
            _mainViewModel.SetPropertyValue(nameof(_mainViewModel.PauseIcon), icons[9]);
        }
    }
}