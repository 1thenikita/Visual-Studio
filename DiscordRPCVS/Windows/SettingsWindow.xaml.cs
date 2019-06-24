using System.Windows;
using System.Windows.Controls;

namespace DiscordRPCVS
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow
    {
        public SettingsWindow() => InitializeComponent();

        private void DiscordRPCSettingsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            IsPresenceEnabled.IsChecked = DiscordRPCVSPackage.Settings.enabled;
            IsFileNameShown.IsChecked = DiscordRPCVSPackage.Settings.showFileName;
            IsSolutionNameShown.IsChecked = DiscordRPCVSPackage.Settings.showSolutionName;
            IsTimestampShown.IsChecked = DiscordRPCVSPackage.Settings.showTimestamp;
            IsTimestampResetEnabled.IsChecked = DiscordRPCVSPackage.Settings.resetTimestamp;
            IsLanguageImageLarge.IsChecked = DiscordRPCVSPackage.Settings.largeLanguage;
            IsTimestampShown_ValueChanged(sender, e);
        }

        private void IsTimestampShown_ValueChanged(object sender, RoutedEventArgs e)
        {
            IsTimestampResetEnabled.IsEnabled = (bool)IsTimestampShown.IsChecked;
            if (IsTimestampShown.IsChecked == true)
                IsLanguageImageLarge.SetValue(Grid.RowProperty, 4);
            else
                IsLanguageImageLarge.SetValue(Grid.RowProperty, 5);
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DiscordRPCVSPackage.Settings.enabled = (bool)IsPresenceEnabled.IsChecked;
            DiscordRPCVSPackage.Settings.showFileName = (bool)IsFileNameShown.IsChecked;
            DiscordRPCVSPackage.Settings.showSolutionName = (bool)IsSolutionNameShown.IsChecked;
            DiscordRPCVSPackage.Settings.showTimestamp = (bool)IsTimestampShown.IsChecked;
            DiscordRPCVSPackage.Settings.resetTimestamp = (bool)IsTimestampResetEnabled.IsChecked;
            DiscordRPCVSPackage.Settings.largeLanguage = (bool)IsLanguageImageLarge.IsChecked;
            DiscordRPCVSPackage.Settings.Save();
            await SettingsCommand.Instance.package.JoinableTaskFactory.SwitchToMainThreadAsync();
            await ((DiscordRPCVSPackage)SettingsCommand.Instance.package).UpdatePresenceAsync(DiscordRPCVSPackage.ide.ActiveDocument, true);
            Close();
        }
    }
}
