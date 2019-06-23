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
            IsPresenceEnabled.IsChecked = DiscordRPCVSPackage.Settings.isPresenceEnabled;
            IsFileNameShown.IsChecked = DiscordRPCVSPackage.Settings.isFileNameShown;
            IsSolutionNameShown.IsChecked = DiscordRPCVSPackage.Settings.isSolutionNameShown;
            IsTimestampShown.IsChecked = DiscordRPCVSPackage.Settings.isTimestampShown;
            IsTimestampResetEnabled.IsChecked = DiscordRPCVSPackage.Settings.isTimestampResetEnabled;
            IsLanguageImageLarge.IsChecked = DiscordRPCVSPackage.Settings.isLanguageImageLarge;
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
            DiscordRPCVSPackage.Settings.isPresenceEnabled = (bool)IsPresenceEnabled.IsChecked;
            DiscordRPCVSPackage.Settings.isFileNameShown = (bool)IsFileNameShown.IsChecked;
            DiscordRPCVSPackage.Settings.isSolutionNameShown = (bool)IsSolutionNameShown.IsChecked;
            DiscordRPCVSPackage.Settings.isTimestampShown = (bool)IsTimestampShown.IsChecked;
            DiscordRPCVSPackage.Settings.isTimestampResetEnabled = (bool)IsTimestampResetEnabled.IsChecked;
            DiscordRPCVSPackage.Settings.isLanguageImageLarge = (bool)IsLanguageImageLarge.IsChecked;
            DiscordRPCVSPackage.Settings.Save();
            await SettingsCommand.Instance.package.JoinableTaskFactory.SwitchToMainThreadAsync();
            await ((DiscordRPCVSPackage)SettingsCommand.Instance.package).UpdatePresenceAsync(DiscordRPCVSPackage.ide.ActiveDocument, true);
            Close();
        }
    }
}
